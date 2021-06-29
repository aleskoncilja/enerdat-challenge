using Enerdat.IOTLibrary.Models.ProcessResults;

namespace Enerdat.IOTLibrary.Models.ProcessParameters
{
    /// <summary>
    /// Send to Rabbit MQ parameters class.
    /// </summary>
    public class SendToRabitMQParameters : IProcessParameters
    {
        /// <summary>
        /// Constructor; init properties with parameters JSON values.
        /// </summary>
        /// <param name="parametersJson">Parameters JSON.</param>
        public SendToRabitMQParameters(dynamic parametersJson)
        {
            // TODO: Use AutoMapper.
            UserName = parametersJson.UserName;
            Password = parametersJson.Password;
            VirtualHost = parametersJson.VirtualHost;
            HostName = parametersJson.HostName;
        }

        /// <summary>
        /// Username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Virtual host.
        /// </summary>
        public string VirtualHost { get; set; }

        /// <summary>
        /// Hostname.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Data - array of process results objects.
        /// </summary>
        public IProcessResults[] Data { get; set; }
    }
}
