using Enerdat.IOTLibrary.Attributes;
using Enerdat.IOTLibrary.Models.ProcessParameters;
using Enerdat.IOTLibrary.Models.ProcessResults;

namespace Enerdat.IOTLibrary.Processes
{
    /// <summary>
    /// Data from API process.
    /// </summary>
    [ProcessName(nameof(DataFromAPIProcess), typeof(DataFromAPIParameters))]
    public class DataFromAPIProcess : BaseProcess, IProcess
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="processParameters">Process parameters.</param>
        public DataFromAPIProcess(DataFromAPIParameters processParameters)
        {
            Parameters = processParameters;
        }

        private DataFromAPIParameters _parameters;
        /// <summary>
        /// Parameters <seealso cref="DataFromAPIParameters"/>.
        /// </summary>
        public IProcessParameters Parameters { get => _parameters; set => _parameters = (DataFromAPIParameters)value; }

        /// <inheritdoc/>
        public IProcessResults Start()
        {
            logger.Info($"Start '{nameof(DataFromAPIProcess)}' process.");

            // TODO: API request to retrieve data of IOT device.
            var results = new DataFromAPIResults("192.168.0.1", (Parameters as DataFromAPIParameters).DeviceId.ToString(), new[] { "ab", "d3", "u6" }, string.Empty);

            return results;
        }
    }
}
