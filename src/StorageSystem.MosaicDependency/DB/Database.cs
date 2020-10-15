using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Text;
using CareFusion.Mosaic.Core.Environment;
using CareFusion.Mosaic.Core.Logging;
using CareFusion.Mosaic.Interfaces.Types.Database;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which implements the logic for a Mosaic database.
    /// This class is used to access any kind of Mosaic database.
    /// No matter whether it is a productive or history database.
    /// </summary>
    public class Database : IDisposable
    {
        #region Constants

        ////////////////////////////////////////////////////////////////
        /// Pragmas
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// Pragma to query the schema version of a SQLite database.
        /// </summary>
        private const string PragmaSchemaVersion = "PRAGMA schema_version;";

        /// <summary>
        /// Pragma to update the schema version of a SQLite database.
        /// </summary>
        private const string PragmaSetSchemaVersion = "PRAGMA schema_version={0};";

        /// <summary>
        /// Pragma to query the custom user version of a SQLite database.
        /// </summary>
        private const string PragmaUserVersion = "PRAGMA user_version;";

        /// <summary>
        /// Pragma to process an integrity check of a SQLite database.
        /// </summary>
        private const string PragmaIntegrityCheck = "PRAGMA integrity_check;";

        /// <summary>
        /// Pragma to update the page size of the database.
        /// </summary>
        private const string PragmaSetPageSize = "PRAGMA page_size = 16384;";

        /// <summary>
        /// Pragma to update the temp store configuration of the database.
        /// </summary>
        private const string PragmaSetTempStore = "PRAGMA temp_store = 2;";

        /// <summary>
        /// Pragma to update the synchronization mode of the database.
        /// </summary>
        private const string PragmaSetSyncMode = "PRAGMA synchronous = 1;";
        
        /// <summary>
        /// Pragma to compress a SQLite database.
        /// </summary>
        private const string PragmaCompress = "VACUUM;";

        #endregion

        #region Members

        /// <summary>
        /// Holds the active SQLite database connection.
        /// </summary>
        private SQLiteConnection _database;

        /// <summary>
        /// Thread synchronization object for accessing the database instance.
        /// </summary>
        private object _syncLock = new object();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the database lock to exclusively lock the database.
        /// </summary>
        public object Lock
        {
            get { return _syncLock; }
        }

        /// <summary>
        /// Gets the user version of the database.
        /// </summary>
        public int Version
        {
            get { return int.Parse(GetPragmaResult(PragmaUserVersion)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the database instance and verifies the schema and user version.
        /// </summary>
        /// <param name="databaseName">Name of the database file.</param>
        /// <param name="schemaPrefix">
        /// The database schema prefix to identify the embedded schema resources.
        /// </param>
        /// <param name="userVersion">
        /// The expected user version of the database -> required for automatic migration logic.
        /// </param>
        /// <param name="inMemory">
        /// Flag whether the database should be hold in memory.
        /// </param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise;</returns>
        public bool Initialize(string databaseName, string schemaPrefix, string userVersion, bool inMemory = false)
        {
            if (string.IsNullOrEmpty(databaseName) ||
                string.IsNullOrEmpty(schemaPrefix))
            {
                return false;
            }

            lock (_syncLock)
            {
                try
                {
                    if ((inMemory == true) || (string.Compare(databaseName, ":memory:") == 0))
                    {
                        if (string.Compare(databaseName, ":memory:") != 0)
                        {
                            string databasePath = Path.Combine(Directories.DataDirectory, databaseName);

                            if (File.Exists(databasePath))
                            {
                                File.Delete(databasePath);
                            }
                        }
                        
                        this.Trace("Opening database '{0}'...", databaseName);
                        _database = new SQLiteConnection("Data Source=:memory:");
                    }
                    else
                    {
                        string databasePath = Path.Combine(Directories.DataDirectory, databaseName);
                        string connString = string.Format("Data Source={0}", databasePath);

                        this.Trace("Opening database '{0}'...", databasePath);
                        _database = new SQLiteConnection(connString);
                    }
                    
                    _database.Open();

                    ExecutePragma(PragmaSetPageSize);
                    ExecutePragma(PragmaSetTempStore);
                    ExecutePragma(PragmaSetSyncMode);

                    this.Trace("Verifying database '{0}'...", databaseName);
                    return VerifyDatabase(schemaPrefix, userVersion);
                }
                catch (Exception ex)
                {
                    this.Error("Initialization of the Mosaic database '{0}' failed.", ex, databaseName);
                }
            }

            return false;
        }

        /// <summary>
        /// Executes a database query according to the requested data type with the specified
        /// filter definitions and returns the first result object.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to query from the database.
        /// </typeparam>
        /// <param name="filters">
        /// The list of query filter definitions to apply.
        /// </param>
        /// <returns>
        /// First object of the result set or null.
        /// </returns>
        public T Get<T>(params CommandFilter[] filters) where T : class, IDatabaseType, new()
        {
            var result = Query<T>(filters);
            return result.Count > 0 ? result[0] : null;
        }

        /// <summary>
        /// Executes a database query according to the requested data type with the specified
        /// filter definitions.
        /// </summary>
        /// <typeparam name="T">The type of object to query from the database.</typeparam>
        /// <param name="filters">The list of query filter definitions to apply.</param>
        /// <returns>List of the queried database object instances if successful; Empty list otherwise.</returns>
        public List<T> Query<T>(params CommandFilter[] filters) where T : class, IDatabaseType, new()
        {
            var queryResultList = new List<T>();
            var queryText = new StringBuilder();
            DataTable queryResultTable = null;

            queryText.Append(CreateCommandWithText(filters));
            queryText.Append(string.Format("SELECT * FROM [{0}s] ", typeof(T).Name));
            queryText.Append(CreateCommandFilterText(filters));

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return queryResultList;
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(queryText.ToString(), _database))
                    {
                        AddCommandFilterParamter(filters, cmd);

                        using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd))
                        {
                            queryResultTable = new DataTable();
                            dataAdapter.Fill(queryResultTable);
                        }
                    }         
                }

                foreach (DataRow row in queryResultTable.Rows)
                {
                    T obj = new T();
                    obj.Load(row, this);
                    queryResultList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                queryResultList.Clear();
                this.Error("Execution of query '{0}' failed.", ex, queryText.ToString());
            }
            finally
            {
                if (queryResultTable != null)
                {
                    queryResultTable.Dispose();
                }
            }

            return queryResultList;
        }

        /// <summary>
        /// Executes a database query according to the requested data type with the specified
        /// filter definitions and an additional row count column.
        /// </summary>
        /// <typeparam name="T">The type of object to query from the database.</typeparam>
        /// <param name="filters">The list of query filter definitions to apply.</param>
        /// <returns>List of the queried database object instances if successful; Empty list otherwise.</returns>
        public List<T> QueryWithRowCount<T>(params CommandFilter[] filters) where T : class, IDatabaseType, new()
        {
            var queryResultList = new List<T>();
            var queryText = new StringBuilder();
            DataTable queryResultTable = null;

            queryText.Append(string.Format("SELECT *, COUNT(*) AS NumRows FROM [{0}s] ", typeof(T).Name));
            queryText.Append(CreateCommandFilterText(filters));

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return queryResultList;
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(queryText.ToString(), _database))
                    {
                        AddCommandFilterParamter(filters, cmd);

                        using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd))
                        {
                            queryResultTable = new DataTable();
                            dataAdapter.Fill(queryResultTable);
                        }
                    }
                }

                foreach (DataRow row in queryResultTable.Rows)
                {
                    T obj = new T();
                    obj.Load(row, this);
                    queryResultList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                queryResultList.Clear();
                this.Error("Execution of query '{0}' failed.", ex, queryText.ToString());
            }
            finally
            {
                if (queryResultTable != null)
                {
                    queryResultTable.Dispose();
                }
            }

            return queryResultList;
        }

        /// <summary>
        /// Executes a database query according to the requested data type with the specified
        /// filter definitions to retrieve the record count of a query.
        /// </summary>
        /// <typeparam name="T">The type of object to query the count from the database.</typeparam>
        /// <param name="filters">The list of query filter definitions to apply.</param>
        /// <returns>Number of query result records if successful; 0 otherwise.</returns>
        public long QueryCount<T>(params CommandFilter[] filters) where T : class, IDatabaseType, new()
        {
            return QueryCount<T>(null, filters);
        }

        /// <summary>
        /// Executes a database query according to the requested data type with the specified
        /// filter definitions to retrieve the record count of a query.
        /// </summary>
        /// <typeparam name="T">The type of object to query the count from the database.</typeparam>
        /// <param name="distinctColumn">The optional distinct column to use.</param>
        /// <param name="filters">The list of query filter definitions to apply.</param>
        /// <returns>
        /// Number of query result records if successful; 0 otherwise.
        /// </returns>
        public long QueryCount<T>(string distinctColumn, params CommandFilter[] filters) where T : class, IDatabaseType, new()
        {
            var queryText = new StringBuilder();

            if (string.IsNullOrEmpty(distinctColumn))
            {
                queryText.Append(string.Format("SELECT COUNT(*) FROM [{0}s] ", typeof(T).Name));
            }
            else
            {
                queryText.Append(string.Format("SELECT COUNT(DISTINCT({0})) FROM [{1}s] ", distinctColumn, typeof(T).Name));
            }

            queryText.Append(CreateCommandFilterText(filters));

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return 0;
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(queryText.ToString(), _database))
                    {
                        AddCommandFilterParamter(filters, cmd);

                        using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                return (long)dataReader[0];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Error("Execution of query '{0}' failed.", ex, queryText.ToString());
            }

            return 0;
        }

        /// <summary>
        /// Executes a database query according to the requested data type with the specified
        /// filter definitions to retrieve the max ID value of a table.
        /// </summary>
        /// <typeparam name="T">The type of object to query the maximum identifier from the database.</typeparam>
        /// <param name="filters">The list of query filter definitions to apply.</param>
        /// <returns>Maximum value of the ID field of the table; 0 otherwise.</returns>
        public long QueryMaxID<T>(params CommandFilter[] filters) where T : class, IDatabaseType, new()
        {
            StringBuilder queryText = new StringBuilder();

            queryText.Append(string.Format("SELECT MAX(ID) FROM [{0}s]", typeof(T).Name));
            queryText.Append(CreateCommandFilterText(filters));

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return 0;
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(queryText.ToString(), _database))
                    {
                        AddCommandFilterParamter(filters, cmd);
                        
                        using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                var result = dataReader[0];
                                return (result == DBNull.Value) ? 0 : (long)result;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Error("Execution of query '{0}' failed.", ex, queryText.ToString());
            }

            return 0;
        }

        /// <summary>
        /// Executes a custom database query according to the requested data type with the specified
        /// filter definitions.
        /// </summary>
        /// <typeparam name="T">The type of object to query from the database.</typeparam>
        /// <param name="customColumns">The custom columns to add to the query.</param>
        /// <param name="filters">The list of query filter definitions to apply.</param>
        /// <returns>List of the queried database object instances if successful; Empty list otherwise.</returns>
        public DataTable QueryCustom<T>(string customColumns, params CommandFilter[] filters) where T : class, IDatabaseType, new()
        {
            if (string.IsNullOrEmpty(customColumns))
            {
                throw new ArgumentException("Invalid customColumns specified.");
            }

            var queryText = new StringBuilder();
            DataTable queryResultTable = null;

            queryText.Append(string.Format("SELECT {0} FROM [{1}s] ", customColumns, typeof(T).Name));
            queryText.Append(CreateCommandFilterText(filters));

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return null;
                    }

                    using (var cmd = new SQLiteCommand(queryText.ToString(), _database))
                    {
                        AddCommandFilterParamter(filters, cmd);

                        using (var dataAdapter = new SQLiteDataAdapter(cmd))
                        {
                            queryResultTable = new DataTable();
                            dataAdapter.Fill(queryResultTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (queryResultTable != null)
                {
                    queryResultTable.Dispose();
                    queryResultTable = null;
                }

                this.Error("Execution of custom query '{0}' failed.", ex, queryText.ToString());
            }

            return queryResultTable;
        }

        /// <summary>
        /// Inserts or updates the database representation of the specified item with all dependencies.
        /// </summary>
        /// <param name="item">The item to update.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        public bool Update(IDatabaseType item)
        {
            return Update(new IDatabaseType[] { item });
        }

        /// <summary>
        /// Inserts or updates the database representation of the specified items with all dependencies.
        /// </summary>
        /// <param name="itemList">The list of items to update.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        public bool Update(IDatabaseType[] itemList)
        {
            if ((itemList == null) || (itemList.Length == 0))
            {
                return false;
            }

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return false;
                    }

                    using (SQLiteTransaction trans = _database.BeginTransaction())
                    {
                        Update(itemList, trans);
                        trans.Commit();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Error("Update of database type '{0}' failed.", ex, itemList[0].GetType().Name);
            }

            return false;
        }

        /// <summary>
        /// Updates the specified column of the specified type according to the specified filter conditions.
        /// </summary>
        /// <typeparam name="T">The type of object to update in the database.</typeparam>
        /// <param name="parameterList">The list of column parameter which define the columns to change.</param>
        /// <param name="filters">The list of update filter definitions to apply.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        public bool Update<T>(CommandParameter parameter, params CommandFilter[] filters) where T : class, IDatabaseType
        {
            return Update<T>(new CommandParameter[] { parameter }, filters);
        }

        /// <summary>
        /// Updates the specified columns of the specified type according to the specified filter conditions.
        /// </summary>
        /// <typeparam name="T">The type of object to update in the database.</typeparam>
        /// <param name="parameterList">The list of column parameter which define the columns to change.</param>
        /// <param name="filters">The list of update filter definitions to apply.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        public bool Update<T>(CommandParameter[] parameterList, params CommandFilter[] filters) where T : class, IDatabaseType
        {
            if (parameterList.Length == 0)
            {
                return false;
            }

            var dtNow = DateTime.UtcNow;
            var commandText = new StringBuilder();
            commandText.Append(string.Format("UPDATE [{0}s] SET ", typeof(T).Name));

            for (int i = 0; i < parameterList.Length; ++i)
            {
                commandText.Append(parameterList[i].ParameterText);
                commandText.Append(",");
            }

            commandText.Append("[LastChange]=@LastChange ");
            commandText.Append(CreateCommandFilterText(filters));

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return false;
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(commandText.ToString(), _database))
                    {
                        foreach (CommandParameter parameter in parameterList)
                        {
                            cmd.Parameters.Add(parameter.Parameter);
                        }

                        cmd.Parameters.Add(new SQLiteParameter("@LastChange", dtNow));
                        AddCommandFilterParamter(filters, cmd);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Error("Execution of update command '{0}' failed.", ex, commandText.ToString());
            }

            return false;
        }

        /// <summary>
        /// Historicizes the database representation of the specified item with all dependencies.
        /// </summary>
        /// <param name="item">The item to historicize.</param>
        /// <param name="historyDate">The optional history date to use.</param>
        /// <returns>
        ///   <c>true</c> if successful;<c>false</c> otherwise.
        /// </returns>
        public bool Historicize(IDatabaseType item, Nullable<DateTime> historyDate = null)
        {
            return Historicize(new IDatabaseType[] { item }, historyDate);
        }

        /// <summary>
        /// Historicizes the database representation of the specified items with all dependencies.
        /// </summary>
        /// <param name="item">The list of items to historicize.</param>
        /// <param name="historyDate">The optional history date to use.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        public bool Historicize(IDatabaseType[] itemList, Nullable<DateTime> historyDate = null)
        {
            if ((itemList == null) || (itemList.Length == 0))
            {
                return false;
            }

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return false;
                    }

                    using (SQLiteTransaction trans = _database.BeginTransaction())
                    {
                        Historicize(itemList, trans, historyDate.HasValue ? historyDate.Value : DateTime.MinValue);
                        trans.Commit();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Error("Historicize of database type '{0}' failed.", ex, itemList[0].GetType().Name);
            }

            return false;
        }

        /// <summary>
        /// Deletes the database representation of the specified item with all dependencies.
        /// </summary>
        /// <param name="item">The item to delete.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        public bool Delete(IDatabaseType item)
        {
            return Delete(new IDatabaseType[] { item });
        }

        /// <summary>
        /// Deletes the database representation of the specified items with all dependencies.
        /// </summary>
        /// <param name="itemList">The list of items to delete.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        public bool Delete(IDatabaseType[] itemList)
        {
            if ((itemList == null) || (itemList.Length == 0))
            {
                return false;
            }

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return false;
                    }

                    using (SQLiteTransaction trans = _database.BeginTransaction())
                    {
                        Delete(itemList, trans);
                        trans.Commit();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                this.Error("Delete of database type '{0}' failed.", ex, itemList[0].GetType().Name);
            }

            return false;
        }

        /// <summary>
        /// Executes a database delete operation according to the specified data type with the specified
        /// filter definitions. The defined filters are concatenated with an AND clause.
        /// </summary>
        /// <typeparam name="T">The type of object to delete from the database.</typeparam>
        /// <param name="filters">The list of filter definitions to apply when executing the delete statement.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        public bool Delete<T>(params CommandFilter[] filters) where T : class, IDatabaseType
        {
            var commandText = new StringBuilder();

            commandText.Append(string.Format("DELETE FROM [{0}s] ", typeof(T).Name));
            commandText.Append(CreateCommandFilterText(filters));

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return false;
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(commandText.ToString(), _database))
                    {
                        AddCommandFilterParamter(filters, cmd);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Error("Execution of delete command '{0}' failed.", ex, commandText.ToString());
            }

            return false;
        }

        /// <summary>
        /// Executes the specified query command and returns the result.
        /// </summary>
        /// <param name="command">The query command to execute.</param>
        /// <returns>According datatable result if successful;null otherwise.</returns>
        public DataTable Execute(SQLiteCommand command)
        {
            if (command == null)
            {
                throw new ArgumentException("Invalid execution command specified.");
            }

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return null;
                    }

                    command.Connection = _database;
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command))
                    {
                        DataTable result = new DataTable();
                        dataAdapter.Fill(result);
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Error("Execution of command '{0}' failed.", ex, command.CommandText);
            }

            return null;
        }

        /// <summary>
        /// Exports the complete database to a file with the specified name.
        /// </summary>
        /// <param name="fileName">Name of the export file.</param>
        /// <returns>
        ///   <c>true</c> if successful, <c>false</c> otherwise
        /// </returns>
        public bool Export(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Invalid fileName specified.");
            }

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return false;
                    }

                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }

                    this.Trace("Exporting database to '{0}'...", fileName);
                    string connectionString = string.Format("Data Source={0}", fileName);

                    using (SQLiteConnection exportFile = new SQLiteConnection(connectionString))
                    {
                        exportFile.Open();
                        _database.BackupDatabase(exportFile, "main", "main", -1, null, 0);
                        string updateSchemaPragma = string.Format(PragmaSetSchemaVersion, GetPragmaResult(PragmaSchemaVersion));

                        using (SQLiteCommand cmdUpdateVersion = new SQLiteCommand(updateSchemaPragma, exportFile))
                        {
                            cmdUpdateVersion.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                this.Error("Exporting database to file '{0}' failed.", ex, fileName);
            }

            return false;
        }

        /// <summary>
        /// Imports the specified file into this database instance.
        /// </summary>
        /// <param name="fileName">Name of the import file.</param>
        /// <returns>
        ///   <c>true</c> if successful, <c>false</c> otherwise
        /// </returns>
        public bool Import(string fileName)
        {
            if ((string.IsNullOrWhiteSpace(fileName)) ||
                (File.Exists(fileName) == false))
            {
                throw new ArgumentException("Invalid fileName specified.");
            }

            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return false;
                    }

                    this.Trace("Importing database from '{0}'...", fileName);
                    string connectionString = string.Format("Data Source={0}", fileName);

                    using (SQLiteConnection importFile = new SQLiteConnection(connectionString))
                    {
                        importFile.Open();
                        importFile.BackupDatabase(_database, "main", "main", -1, null, 0);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                this.Error("Exporting database to file '{0}' failed.", ex, fileName);
            }

            return false;
        }

        /// <summary>
        /// Determines whether the database contains the specified table.
        /// </summary>
        /// <param name="tableName">Name of the table to check.</param>
        /// <returns>
        /// <c>true</c> if the table is in the database;<c>false</c> otherwise.
        /// </returns>
        public bool ContainsTable(string tableName)
        {
            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                        return false;

                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@tblname;", _database))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("tblname", tableName));

                        using (var dataReader = cmd.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                return (long)dataReader[0] > 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Error("Execution of table query failed.", ex);
            }

            return false;
        }
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            lock (_syncLock)
            {
                if (_database != null)
                {
                    _database.Dispose();
                    _database = null;
                }
            }
        }

        /// <summary>
        /// Verifies the schema structure of the currently opened database.
        /// </summary>
        /// <param name="schemaPrefix">
        /// The database schema prefix to identify the embedded schema resources.
        /// </param>
        /// <param name="userVersion">
        /// The expected user version of the database -> required for automatic migration logic.
        /// </param>
        /// <returns>
        ///   <c>true</c> if verification finished successfully;<c>false</c> otherwise.
        /// </returns>
        private bool VerifyDatabase(string schemaPrefix, string userVersion)
        {
            string schemaVersion = GetPragmaResult(PragmaSchemaVersion);
            string currentUserVersion = GetPragmaResult(PragmaUserVersion);

            if ((string.IsNullOrEmpty(schemaVersion)) || (string.Compare(schemaVersion, "0") == 0))
            {
                if (GenerateDatabase(schemaPrefix) == false)
                {
                    return false;
                }

                currentUserVersion = GetPragmaResult(PragmaUserVersion);
            }

            if (string.IsNullOrEmpty(userVersion))
            { 
                // skip user version checks
                return true;
            }

            int expectedVersion = int.Parse(userVersion);
            int currentVersion = int.Parse(currentUserVersion);

            if (currentVersion == expectedVersion)
            {
                return true;
            }

            if (currentVersion > expectedVersion)
            {
                this.Error("Database with user version '{0}' is newer than the expected user version '{1}'.",
                           currentVersion, expectedVersion);
                return false;
            }

            return MigrateDatabase(schemaPrefix, currentVersion, expectedVersion);
        }

        /// <summary>
        /// Generates the database schema from scratch by loading the appropriate schema from the embedded resources.
        /// </summary>
        /// <param name="schemaPrefix">
        /// The database schema prefix to identify the embedded schema resources.
        /// </param>
        /// <returns>
        /// <c>true</c> if database generation finished successfully;<c>false</c> otherwise.
        /// </returns>
        private bool GenerateDatabase(string schemaPrefix)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            string[] schemaStreamNameList = thisAssembly.GetManifestResourceNames();
            string schemaFilter = string.Format("CareFusion.Mosaic.DB.Schema.{0}", schemaPrefix);

            if ((schemaStreamNameList == null) || (schemaStreamNameList.Length == 0))
            {
                this.Error("No embedded database schema files found.");
                return false;
            }

            Array.Sort(schemaStreamNameList);

            using (SQLiteTransaction trans = _database.BeginTransaction())
            {
                foreach (string schemaStreamName in schemaStreamNameList)
                {
                    if ((schemaStreamName.StartsWith(schemaFilter) == false) ||
                        (schemaStreamName.StartsWith(schemaFilter + "MIG")) ||
                        (schemaStreamName.EndsWith(".sql", StringComparison.InvariantCultureIgnoreCase) == false))
                    {
                        continue;
                    }

                    this.Trace("Executing schema script '{0}'.", schemaStreamName);

                    string schemaContent = string.Empty;
                    Stream schemaStream = thisAssembly.GetManifestResourceStream(schemaStreamName);
                    using (StreamReader schemaReader = new StreamReader(schemaStream))
                    {
                        schemaContent = schemaReader.ReadToEnd();
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(schemaContent,
                                                                 _database,
                                                                 trans))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                trans.Commit();
            }

            return true;
        }

        /// <summary>
        /// Migrates the database from the current version to the expected version by executing the migration scripts.
        /// </summary>
        /// <param name="schemaPrefix">The schema prefix to use when searching for migration scripts.</param>
        /// <param name="currentVersion">The current version where to start the migration from.</param>
        /// <param name="expectedVersion">The expected version to reach during migration.</param>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise.</returns>
        private bool MigrateDatabase(string schemaPrefix, int currentVersion, int expectedVersion)
        {
            this.Info("Migrating database from user version '{0}' to user version '{1}'.", currentVersion, expectedVersion);

            bool result = false;
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            string[] schemaStreamNameList = thisAssembly.GetManifestResourceNames();
            string schemaFilter = string.Format("CareFusion.Mosaic.DB.Migration.{0}MIG", schemaPrefix);

            if ((schemaStreamNameList == null) || (schemaStreamNameList.Length == 0))
            {
                this.Error("No embedded database migration files found.");
                return false;
            }

            // first create backup of the original database            
            string originalFileName = _database.ConnectionString.Substring(_database.ConnectionString.LastIndexOf('=') + 1);
            string backupFileName = string.Format("MigrationBackup_{0}_{1}_{2}.db", schemaPrefix, currentVersion, expectedVersion);
            backupFileName = Path.Combine(Directories.DataDirectory, backupFileName);

            if (Export(backupFileName) == false)
            {
                return false;
            }

            try
            {
                using (SQLiteTransaction trans = _database.BeginTransaction())
                {
                    for (int i = currentVersion; i < expectedVersion; ++i)
                    {
                        foreach (string schemaStreamName in schemaStreamNameList)
                        {
                            if ((schemaStreamName.StartsWith(schemaFilter + i) == false) ||
                                (schemaStreamName.EndsWith(".sql", StringComparison.InvariantCultureIgnoreCase) == false))
                            {
                                continue;
                            }

                            this.Trace("Executing migration script '{0}'.", schemaStreamName);

                            string schemaContent = string.Empty;
                            Stream schemaStream = thisAssembly.GetManifestResourceStream(schemaStreamName);
                            using (StreamReader schemaReader = new StreamReader(schemaStream))
                            {
                                schemaContent = schemaReader.ReadToEnd();
                            }

                            using (SQLiteCommand cmd = new SQLiteCommand(schemaContent,
                                                                         _database,
                                                                         trans))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    trans.Commit();
                }

                int migratedVersion = int.Parse(GetPragmaResult(PragmaUserVersion));
                string checkResult = GetPragmaResult(PragmaIntegrityCheck).ToLower().Trim();

                if (migratedVersion != expectedVersion)
                {
                    this.Error("The migrated database user version '{0}' does not fit to the expected user version '{1}'.", 
                               migratedVersion, expectedVersion);
                }
                else if (checkResult != "ok")
                {
                    this.Error("The migrated database failed the integrity check with result '{0}'.", checkResult);
                }
                else
                {
                    ExecutePragma(PragmaCompress);
                    this.Info("Successfully migrated the database from user version '{0}' to user version '{1}'.", currentVersion, expectedVersion);                    
                    result = true;
                }
            }
            catch (Exception ex)
            {
                this.Error("Migrating database from user version '{0}' to user version '{1}' failed.", ex, currentVersion, expectedVersion);
            }

            if (result == false)
            {
                this.Info("Restoring database backup '{0}'.", backupFileName);

                _database.Close();
                _database.Dispose();
                _database = null;
                File.Copy(backupFileName, originalFileName, true);
                File.Delete(backupFileName);
            }

            return result;
        }

        /// <summary>
        /// Executes the specified pragma command and returns the first column
        /// of the first result row.
        /// </summary>
        /// <param name="pragma">The pragma command to execute.</param>
        /// <returns>The first column of the first result row if successful; emtpy string otherwise.</returns>
        private string GetPragmaResult(string pragma)
        {
            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return string.Empty;
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(pragma, _database))
                    {
                        using (SQLiteDataReader dataReader = cmd.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                return dataReader[0].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Error("Executing pragma '{0}' failed.", ex, pragma);
            }

            return string.Empty;
        }

        /// <summary>
        /// Executes the specified pragma command
        /// </summary>
        /// <param name="pragma">The pragma command to execute.</param>
        private void ExecutePragma(string pragma)
        {
            try
            {
                lock (_syncLock)
                {
                    if (_database == null)
                    {
                        return;
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(pragma, _database))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Error("Executing pragma '{0}' failed.", ex, pragma);
            }
        }

        /// <summary>
        /// Inserts or updates the database representation of the specified items with all dependencies
        /// with the specified transaction.
        /// </summary>
        /// <param name="itemList">The list of items to update.</param>
        /// <param name="transaction">The transaction to use for the update.</param>
        private void Update(IDatabaseType[] itemList, SQLiteTransaction transaction)
        {
            string[] propertyNames = itemList[0].PropertyNames;
            object[] propertyValues = itemList[0].PropertyValues;

            if ((propertyNames == null) || (propertyNames.Length == 0) ||
                (propertyValues == null) || (propertyNames.Length != propertyValues.Length))
            {
                throw new InvalidDataException(string.Format("Property Name/Value mismatch for database type '{0}'",
                                                             itemList[0].GetType().Name));
            }

            DateTime dtLastChange = DateTime.UtcNow;
            StringBuilder cmdText = new StringBuilder();
            List<IDatabaseType[]> dependencyList = new List<IDatabaseType[]>();

            cmdText.Append(string.Format("INSERT OR REPLACE INTO {0}s(", itemList[0].GetType().Name));

            for (int i = 0; i < propertyNames.Length; ++i)
            {
                cmdText.Append(string.Format("[{0}]", propertyNames[i]));
                cmdText.Append(",");
            }

            cmdText.Append("[LastChange]) VALUES (");

            for (int i = 0; i < propertyNames.Length; ++i)
            {
                cmdText.Append(string.Format("@{0}", propertyNames[i]));
                cmdText.Append(",");
            }

            cmdText.Append("@LastChange);");

            using (SQLiteCommand cmdUpdate = new SQLiteCommand(cmdText.ToString(), _database, transaction))
            {
                for (int i = 0; i < propertyNames.Length; ++i)
                {
                    cmdUpdate.Parameters.Add(new SQLiteParameter(string.Format("@{0}", propertyNames[i]),
                                                                 new SQLiteParameter("Dummy", propertyValues[i]).DbType));
                }

                cmdUpdate.Parameters.Add(new SQLiteParameter("@LastChange", DbType.DateTime));
                cmdUpdate.Prepare();

                foreach (var item in itemList)
                {
                    propertyValues = item.PropertyValues;

                    int i = 0;                    
                    for (i = 0; i < propertyValues.Length; ++i)
                    {
                        cmdUpdate.Parameters[i].Value = propertyValues[i];
                    }

                    cmdUpdate.Parameters[i].Value = dtLastChange;
                    cmdUpdate.ExecuteNonQuery();

                    var dependencies = item.Dependencies;

                    if (dependencies != null)
                    {
                        dependencyList.AddRange(dependencies);
                    }
                }
            }

            foreach (var dependency in dependencyList)
            {
                if (dependency.Length > 0)
                {
                    Update(dependency, transaction);
                }
            }
        }

        /// <summary>
        /// Historicizes the database representation of the specified items with all dependencies
        /// with the specified transaction.
        /// </summary>
        /// <param name="itemList">The list of items to historicize.</param>
        /// <param name="transaction">The transaction to use for the historicize operation.</param>
        /// <param name="historyDate">The history date to use for the historicize operation.</param>
        private void Historicize(IDatabaseType[] itemList, SQLiteTransaction transaction, DateTime historyDate)
        {
            string[] propertyNames = itemList[0].PropertyNames;
            object[] propertyValues = itemList[0].PropertyValues;

            if ((propertyNames == null) || (propertyNames.Length == 0) ||
                (propertyValues == null) || (propertyNames.Length != propertyValues.Length))
            {
                throw new InvalidDataException(string.Format("Property Name/Value mismatch for database type '{0}'",
                                                             itemList[0].GetType().Name));
            }

            if (historyDate == DateTime.MinValue)
            {
                historyDate = DateTime.UtcNow;
            }

            StringBuilder cmdText = new StringBuilder();
            List<IDatabaseType[]> dependencyList = new List<IDatabaseType[]>();

            cmdText.Append(string.Format("INSERT INTO {0}s(", itemList[0].GetType().Name));

            for (int i = 0; i < propertyNames.Length; ++i)
            {
                cmdText.Append(string.Format("[{0}]", propertyNames[i]));
                cmdText.Append(",");
            }

            cmdText.Append("[HistoryDate]) VALUES (");

            for (int i = 0; i < propertyNames.Length; ++i)
            {
                cmdText.Append(string.Format("@{0}", propertyNames[i]));
                cmdText.Append(",");
            }

            cmdText.Append("@HistoryDate);");

            using (SQLiteCommand cmdUpdate = new SQLiteCommand(cmdText.ToString(), _database, transaction))
            {
                for (int i = 0; i < propertyNames.Length; ++i)
                {
                    cmdUpdate.Parameters.Add(new SQLiteParameter(string.Format("@{0}", propertyNames[i]),
                                                                 new SQLiteParameter("Dummy", propertyValues[i]).DbType));
                }

                cmdUpdate.Parameters.Add(new SQLiteParameter("@HistoryDate", DbType.DateTime));
                cmdUpdate.Prepare();

                foreach (var item in itemList)
                {
                    propertyValues = item.PropertyValues;

                    for (int i = 0; i < propertyValues.Length; ++i)
                    {
                        cmdUpdate.Parameters[i].Value = propertyValues[i];
                    }

                    cmdUpdate.Parameters[propertyValues.Length].Value = historyDate;
                    cmdUpdate.ExecuteNonQuery();

                    var dependencies = item.Dependencies;

                    if (dependencies != null)
                    {
                        dependencyList.AddRange(dependencies);
                    }
                }
            }

            foreach (var dependency in dependencyList)
            {
                if (dependency.Length > 0)
                {
                    Historicize(dependency, transaction, historyDate);
                }
            }
        }

        /// <summary>
        /// Deletes the database representation of the specified items with all dependencies
        /// with the specified transaction.
        /// </summary>
        /// <param name="itemList">The list of items to delete.</param>
        /// <param name="transaction">The transaction to use for the delete.</param>
        private void Delete(IDatabaseType[] itemList, SQLiteTransaction transaction)
        {
            string[] keyPropertyNames = itemList[0].KeyPropertyNames;
            object[] keyPropertyValues = itemList[0].KeyPropertyValues;

            if ((keyPropertyNames == null) || (keyPropertyNames.Length == 0) ||
                (keyPropertyValues == null) || (keyPropertyNames.Length != keyPropertyValues.Length))
            {
                throw new InvalidDataException(string.Format("Key property Name/Value mismatch for database type '{0}'",
                                                             itemList[0].GetType().Name));
            }

            StringBuilder cmdText = new StringBuilder();
            List<IDatabaseType[]> dependencyList = new List<IDatabaseType[]>();

            cmdText.Append(string.Format("DELETE FROM {0}s WHERE ", itemList[0].GetType().Name));

            for (int i = 0; i < keyPropertyNames.Length; ++i)
            {
                cmdText.Append(string.Format("{0}=@{0}", keyPropertyNames[i]));

                if (i < keyPropertyNames.Length - 1)
                {
                    cmdText.Append(" AND ");
                }
                else
                {
                    cmdText.Append(";");
                }
            }

            foreach (var item in itemList)
            {
                var dependencies = item.Dependencies;

                if (dependencies != null)
                {
                    dependencyList.AddRange(dependencies);
                }
            }

            foreach (var dependency in dependencyList)
            {
                if (dependency.Length > 0)
                {
                    Delete(dependency, transaction);
                }
            }

            using (SQLiteCommand cmdDelete = new SQLiteCommand(cmdText.ToString(), _database, transaction))
            {
                for (int i = 0; i < keyPropertyNames.Length; ++i)
                {
                    cmdDelete.Parameters.Add(new SQLiteParameter(string.Format("@{0}", keyPropertyNames[i]),
                                                                 new SQLiteParameter("Dummy", keyPropertyValues[i]).DbType));
                }

                cmdDelete.Prepare();

                foreach (var item in itemList)
                {
                    keyPropertyValues = item.KeyPropertyValues;

                    for (int i = 0; i < keyPropertyValues.Length; ++i)
                    {
                        cmdDelete.Parameters[i].Value = keyPropertyValues[i];
                    }

                    cmdDelete.ExecuteNonQuery();                   
                }
            }            
        }

        /// <summary>
        /// Creates the withs command text based on the specifed filter list.
        /// </summary>
        /// <param name="filters">
        /// The filters to create the with command text for.
        /// </param>
        /// <returns>
        /// Created filter command text.
        /// </returns>
        private static string CreateCommandWithText(CommandFilter[] filters)
        {
            if ((filters == null) || (filters.Length == 0))
            {
                return string.Empty;
            }

            var withClauseText = new StringBuilder();
            for (int i = 0; i < filters.Length; ++i)
            {
                CommandFilterWithClause filterWithClause = filters[i] as CommandFilterWithClause;
                if (filterWithClause != null)
                {
                    withClauseText.AppendLine(filterWithClause.GetWithClauseText());
                }
            }

            return withClauseText.ToString();
        }

        /// <summary>
        /// Creates the filter command text based on the specifed filter list.
        /// </summary>
        /// <param name="filters">
        /// The filters to create the command text for.
        /// </param>
        /// <returns>
        /// Created filter command text.
        /// </returns>
        private static string CreateCommandFilterText(CommandFilter[] filters)
        {
            if ((filters == null) || (filters.Length == 0))
            {
                return string.Empty;
            }

            var filterText = new StringBuilder();
            var isWhereClauseRequired = false;

            for (int i = 0; i < filters.Length; ++i)
            {
                if (filters[i].HasParameter)
                {
                    isWhereClauseRequired = true;
                    break;
                }
            }

            if (isWhereClauseRequired)
            {
                filterText.Append(" WHERE ");
            }

            for (int i = 0; i < filters.Length; ++i)
            {
                filterText.Append(filters[i].FilterText);

                if (i < filters.Length - 1)
                {
                    if (string.IsNullOrEmpty(filters[i + 1].ConcatText) == false)
                    {
                        filterText.Append(string.Format(" {0} ", filters[i].ConcatText));
                    }
                    else
                    {
                        filterText.Append(" ");
                    }
                }
            }

            filterText.Append(";");

            return filterText.ToString();
        }

        /// <summary>
        /// Add the specified filters as command parameters to the specified command.
        /// </summary>
        /// <param name="filters">
        /// The filters to add as command parameters.
        /// </param>
        /// <param name="command">
        /// The command to add the parameters to.
        /// </param>
        private static void AddCommandFilterParamter(CommandFilter[] filters, SQLiteCommand command)
        {
            if ((filters == null) || (filters.Length == 0))
            {
                return;
            }

            if (command == null)
            {
                throw new ArgumentException("Invalid command specified.");
            }

            foreach (var filter in filters)
            {
                if (filter is CommandFilterWithClause)
                {
                    CommandFilterWithClause filterWithClause = filter as CommandFilterWithClause;
                    
                    foreach (var commandFilter in filterWithClause.GetWithClauseCommandFilter())
                    {
                        var parameter = commandFilter.FilterParameter;

                        if (parameter != null)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                }

                if (filter is CommandMultiFilter)
                {
                    var group = filter as CommandMultiFilter;

                    foreach (var commandFilter in group.CommandFilter)
                    {
                        var parameter = commandFilter.FilterParameter;

                        if (parameter != null)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                }
                else
                {
                    var parameter = filter.FilterParameter;

                    if (parameter != null)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
            }
        }

        #endregion
    }
}
