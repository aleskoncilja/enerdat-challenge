using Enerdat.IOTLibrary.Attributes;
using Enerdat.IOTLibrary.Models.ProcessParameters;
using Enerdat.IOTLibrary.Models.ProcessResults;
using System;

namespace Enerdat.IOTLibrary.Processes
{
    /// <summary>
    /// Data from IO process class.
    /// </summary>
    [ProcessName(nameof(DataFromIOTProcess), typeof(DataFromIOTParameters))]
    public class DataFromIOTProcess : BaseProcess, IProcess
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="processParameters">Process parameters.</param>
        public DataFromIOTProcess(DataFromIOTParameters processParameters)
        {
            Parameters = processParameters;
        }

        private DataFromIOTParameters _parameters;
        /// <summary>
        /// Parameters <seealso cref="DataFromIOTParameters"/>.
        /// </summary>
        public IProcessParameters Parameters { get => _parameters; set => _parameters = (DataFromIOTParameters)value; }

        /// <inheritdoc/>
        public IProcessResults Start()
        {
            logger.Info($"Start '{nameof(DataFromIOTProcess)}' process.");

            // TODO: Connect to IOT device to retrieve temperature.
            var results = new DataFromIOTResults(((int)(new Random().NextDouble() * 69 * 100)) / 100);

            return results;
        }
    }
}
