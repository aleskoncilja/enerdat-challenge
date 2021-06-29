using Enerdat.IOTLibrary.Providers;
using NLog;

namespace Enerdat.IOTLibrary.Processes
{
    /// <summary>
    /// Base process class.
    /// </summary>
    public class BaseProcess
    {
        /// <summary>
        /// Logger.
        /// </summary>
        protected readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Database provider instance.
        /// </summary>
        protected readonly IDbProvider dbProvider = new DbProvider(@"Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;Password=myPassword;");

        /// <summary>
        /// Rabbit MQ provider instance.
        /// </summary>
        protected readonly IRabbitMQProvider rabbitMQProvider = new RabbitMQProvider("admin", "admin", "vh1", "rabbitmq.local:15672");
    }
}
