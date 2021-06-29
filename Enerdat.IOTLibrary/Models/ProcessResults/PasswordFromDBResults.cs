namespace Enerdat.IOTLibrary.Models.ProcessResults
{
    /// <summary>
    /// Password from DB results class.
    /// </summary>
    public class PasswordFromDBResults : IProcessResults
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="passwordRetrieved">Password retrieved.</param>
        public PasswordFromDBResults(bool passwordRetrieved)
        {
            PasswordRetrieved = passwordRetrieved;
        }

        /// <summary>
        /// If password successfully retrieved from database.
        /// </summary>
        public bool PasswordRetrieved { get; set; }
    }
}
