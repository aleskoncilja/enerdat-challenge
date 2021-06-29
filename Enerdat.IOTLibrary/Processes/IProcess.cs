using Enerdat.IOTLibrary.Models.ProcessParameters;
using Enerdat.IOTLibrary.Models.ProcessResults;

namespace Enerdat.IOTLibrary.Processes
{
    /// <summary>
    /// Process interface.
    /// </summary>
    public interface IProcess
    {
        /// <summary>
        /// Process parameters.
        /// </summary>
        IProcessParameters Parameters { get; set; }

        /// <summary>
        /// Start process with parameters and return results. Parameters to start process is an object of implementation <seealso cref="IProcessParameters"/> interface.</param>
        /// </summary>
        /// <returns>Results of process is implementation of <seealso cref="IProcessResults"/> interface.</returns>
        IProcessResults Start();
    }
}
