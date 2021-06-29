using System;

namespace Enerdat.IOTLibrary.Models.ProcessParameters
{
    /// <summary>
    /// Data from API parameters class.
    /// </summary>
    public class DataFromAPIParameters : IProcessParameters
    {
        /// <summary>
        /// Constructor; init properties with parameters JSON values.
        /// </summary>
        /// <param name="parametersJson">Parameters JSON.</param>
        public DataFromAPIParameters(dynamic parametersJson)
        {
            // TODO: Use AutoMapper.
            Url = parametersJson.Url;
            UserName = parametersJson.UserName;
            Password = parametersJson.Password;
            DeviceId = new Guid(parametersJson.DeviceId.ToString());
        }

        /// <summary>
        /// Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Device Id (guid).
        /// </summary>
        public Guid DeviceId { get; set; }
    }
}
