using System;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Class which contains the set of all Mosaic related databases.
    /// </summary>
    public class DatabaseSet : IDisposable
    {
        #region Constants

        ////////////////////////////////////////////////////////////////
        /// Version Numbers
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// Actual user version of the productive database.
        /// </summary>
        public const string DbUserVersionProductive = "19";

        /// <summary>
        /// Actual user version of the history database.
        /// </summary>
        public const string DbUserVersionHistory = "13";

        /// <summary>
        /// Actual user version of the stock cache database.
        /// </summary>
        public const string DbUserVersionStockCache = "2";

        ////////////////////////////////////////////////////////////////
        /// File Names
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// File name of the productive Mosaic database.
        /// </summary>
        public const string DbNameProductive = "Mosaic.db";

        /// <summary>
        /// File name of the Mosaic history database.
        /// </summary>
        public const string DbNameHistory = "Mosaic-History.db";

        /// <summary>
        /// File name of the Mosaic stock cache database.
        /// </summary>
        public const string DbNameStockCache = "Mosaic-StockCache.db";

        #endregion

        #region Members

        /// <summary>
        /// Holds the currently active database instance with the productive Mosaic data.
        /// </summary>
        private Database _dbProductive = new Database();

        /// <summary>
        /// Holds the currently active database instance with the Mosaic history data.
        /// </summary>
        private Database _dbHistory = new Database();

        /// <summary>
        /// Holds the currently active database instance with the Mosaic stock cache data.
        /// </summary>
        private Database _dbStockCache = new Database();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance of the productive Mosaic database.
        /// </summary>
        public Database Productive
        {
            get { return _dbProductive; }
        }

        /// <summary>
        /// Gets the instance of the Mosaic history database.
        /// </summary>
        public Database History
        {
            get { return _dbHistory; }
        }

        /// <summary>
        /// Gets the instance of the Mosaic stock cache database.
        /// </summary>
        public Database StockCache
        {
            get { return _dbStockCache; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Opens the productive Mosaic database without any validity checks/migration operations.
        /// </summary>
        /// <returns>Opened productive database if successful; null otherwise.</returns>
        public static Database OpenProductiveDatabase()
        {
            Database db = new Database();

            if (db.Initialize(DbNameProductive, "P", null) == false)
            {
                db.Dispose();
                return null;
            }

            return db;
        }

        /// <summary>
        /// Initializes all Mosaic databases which belong to this database set.
        /// </summary>
        /// <returns><c>true</c> if successful;<c>false</c> otherwise;</returns>
        public bool Initialize()
        {
            return _dbProductive.Initialize(DbNameProductive, "P", DbUserVersionProductive) &&
                   _dbHistory.Initialize(DbNameHistory, "H", DbUserVersionHistory) &&
                   _dbStockCache.Initialize(DbNameStockCache, "S", DbUserVersionStockCache, true);
        }

        /// <summary>
        /// Initializes all Mosaic databases with the specified database names.
        /// </summary>
        /// <param name="productiveDbName">Name of the productive database.</param>
        /// <param name="historyDbNamme">The history database name.</param>
        /// <param name="stockCacheDbName">The stock cache database name.</param>
        /// <returns>
        ///   <c>true</c> if successful;<c>false</c> otherwise;
        /// </returns>
        public bool Initialize(string productiveDbName, string historyDbNamme, string stockCacheDbName)
        {
            return _dbProductive.Initialize(productiveDbName, "P", DbUserVersionProductive) &&
                   _dbHistory.Initialize(historyDbNamme, "H", DbUserVersionHistory) &&
                   _dbStockCache.Initialize(stockCacheDbName, "S", DbUserVersionStockCache);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _dbHistory.Dispose();
            _dbProductive.Dispose();
            _dbStockCache.Dispose();
        }

        #endregion
    }
}
