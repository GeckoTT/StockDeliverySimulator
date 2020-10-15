using System;
using System.Threading;

namespace CareFusion.Mosaic.DB
{
    /// <summary>
    /// Small helper class which allows global database locking for multiple operations.
    /// </summary>
    public class DatabaseLock : IDisposable
    {
        #region Members

        /// <summary>
        /// Holds the database lock object.
        /// </summary>
        private object _databaseLock;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseLock"/> class.
        /// </summary>
        /// <param name="database">The database to lock.</param>
        public DatabaseLock(Database database)
        {
            if (database == null)
            {
                return;
            }

            _databaseLock = database.Lock;

            if (_databaseLock != null)
            {
                Monitor.Enter(_databaseLock);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_databaseLock != null)
            {
                Monitor.Exit(_databaseLock);
            }
        }
    }
}
