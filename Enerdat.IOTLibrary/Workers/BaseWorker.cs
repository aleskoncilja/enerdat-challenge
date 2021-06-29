using NLog;

namespace Enerdat.IOTLibrary.Workers
{
    /// <summary>
    /// Base worker class.
    /// </summary>
    public class BaseWorker
    {
        /// <summary>
        /// Logger.
        /// </summary>
        protected readonly Logger logger = LogManager.GetCurrentClassLogger();
    }
}
