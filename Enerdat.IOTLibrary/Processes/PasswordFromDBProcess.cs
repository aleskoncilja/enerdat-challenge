using Enerdat.IOTLibrary.Attributes;
using Enerdat.IOTLibrary.Models.ProcessParameters;
using Enerdat.IOTLibrary.Models.ProcessResults;

namespace Enerdat.IOTLibrary.Processes
{
    /// <summary>
    /// Password from DB process class.
    /// </summary>
    [ProcessName(nameof(PasswordFromDBProcess), typeof(PasswordFromDBParameters))]
    public class PasswordFromDBProcess : BaseProcess, IProcess
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="processParameters">Process parameters.</param>
        public PasswordFromDBProcess(PasswordFromDBParameters processParameters)
        {
            Parameters = processParameters;
        }

        private PasswordFromDBParameters _parameters;
        /// <summary>
        /// Parameters <seealso cref="PasswordFromDBParameters"/>.
        /// </summary>
        public IProcessParameters Parameters { get => _parameters; set => _parameters = (PasswordFromDBParameters)value; }

        /// <inheritdoc/>
        public IProcessResults Start()
        {
            logger.Info($"Start '{nameof(PasswordFromDBProcess)}' process.");

            var passwordValidated = dbProvider.GetPassword("myPassword");
            var results = new PasswordFromDBResults(passwordValidated);

            return results;
        }
    }
}
