using NLog;
using System;

namespace Enerdat.IOTLibrary.Providers
{
    /// <summary>
    /// Database provider class.
    /// </summary>
    public class DbProvider : IDbProvider
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        public DbProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        private string _connectionString { get; set; }

        /// <inheritdoc/>
        public bool GetPassword(string password)
        {
            _logger.Debug($"{nameof(DbProvider)} {nameof(GetPassword)}.");

            return DateTime.Now.Ticks % 2 == 0;
        }
    }
}