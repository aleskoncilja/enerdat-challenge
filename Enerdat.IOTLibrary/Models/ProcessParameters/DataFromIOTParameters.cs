namespace Enerdat.IOTLibrary.Models.ProcessParameters
{
    /// <summary>
    /// Data from IOT device parameters class.
    /// </summary>
    public class DataFromIOTParameters : IProcessParameters
    {
        /// <summary>
        /// Constructor; init properties with parameters JSON values.
        /// </summary>
        /// <param name="parametersJson">Parameters JSON.</param>
        public DataFromIOTParameters(dynamic parametersJson)
        {
            // TODO: Use AutoMapper.
            Url = parametersJson.Url;
            UserName = parametersJson.UserName;
            Password = parametersJson.Password;
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
    }
}
