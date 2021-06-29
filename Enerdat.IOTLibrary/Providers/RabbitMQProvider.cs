using Enerdat.IOTLibrary.Models.ProcessResults;
using NLog;
using RabbitMQ.Client;

namespace Enerdat.IOTLibrary.Providers
{
    /// <summary>
    /// Rabbit MQ provider class.
    /// </summary>
    public class RabbitMQProvider : IRabbitMQProvider
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private IConnection connection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="user">Username.</param>
        /// <param name="pass">Password.</param>
        /// <param name="vhost">Virtual host.</param>
        /// <param name="hostName">Hostname.</param>
        public RabbitMQProvider(string user, string pass, string vhost, string hostName)
        {
            var factory = new ConnectionFactory
            {
                UserName = user,
                Password = pass,
                VirtualHost = vhost,
                HostName = hostName
            };
            connection = null;  // = factory.CreateConnection();
        }

        /// <inheritdoc/>
        public void Push(IProcessResults[] data)
        {
            _logger.Debug($"{nameof(RabbitMQProvider)} {nameof(Push)}: data contain {data.Length} items.");

            // TODO:
            //throw new System.NotImplementedException();
        }
    }
}