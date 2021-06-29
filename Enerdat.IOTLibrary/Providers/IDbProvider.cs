namespace Enerdat.IOTLibrary.Providers
{
    /// <summary>
    /// Database provider interface.
    /// </summary>
    public interface IDbProvider
    {
        /// <summary>
        /// Validate password.
        /// </summary>
        /// <returns></returns>
        bool GetPassword(string password);
    }
}
