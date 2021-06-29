using Enerdat.IOTLibrary.Attributes;
using Enerdat.IOTLibrary.Models.ProcessParameters;
using Enerdat.IOTLibrary.Models.ProcessResults;
using System;

namespace Enerdat.IOTLibrary.Processes
{
    /// <summary>
    /// Send to Rabbit MQ process class.
    /// </summary>
    [ProcessName(nameof(SendToRabitMQProcess), typeof(SendToRabitMQParameters))]
    public class SendToRabitMQProcess : BaseProcess, IProcess
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="processParameters">Process parameters.</param>
        public SendToRabitMQProcess(SendToRabitMQParameters processParameters)
        {
            Parameters = processParameters;
        }

        private SendToRabitMQParameters _parameters;
        /// <summary>
        /// Parameters <seealso cref="SendToRabitMQParameters"/>.
        /// </summary>
        public IProcessParameters Parameters { get => _parameters; set => _parameters = (SendToRabitMQParameters)value; }

        /// <inheritdoc/>
        public IProcessResults Start()
        {
            logger.Info($"Start '{nameof(SendToRabitMQProcess)}' process.");

            // TODO: Upgrade push to Rabbit MQ method.
            rabbitMQProvider.Push(((SendToRabitMQParameters)Parameters).Data);

            var results = new SendToRabitMQResults(DateTime.Now.Ticks % 2 == 0);

            return results;
        }
    }
}
