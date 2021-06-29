namespace Enerdat.IOTLibrary.Models.ProcessParameters
{
    /// <summary>
    /// Password from DB parameters class.
    /// </summary>
    public class PasswordFromDBParameters : IProcessParameters
    {
        /// <summary>
        /// Constructor; init properties with parameters JSON values.
        /// </summary>
        /// <param name="parametersJson">Parameters JSON.</param>
        public PasswordFromDBParameters(dynamic parametersJson)
        {
            // TODO: Use AutoMapper.
            Server = parametersJson.Server;
            Database = parametersJson.Database;
            UserName = parametersJson.UserName;
            Password = parametersJson.Password;
        }

        /// <summary>
        /// Server.
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Database.
        /// </summary>
        public string Database { get; set; }

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
