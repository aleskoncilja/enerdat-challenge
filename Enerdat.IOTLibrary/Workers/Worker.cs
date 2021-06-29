using Enerdat.IOTLibrary.Models.ProcessParameters;
using Enerdat.IOTLibrary.Models.ProcessResults;
using Enerdat.IOTLibrary.Processes;
using Enerdat.IOTLibrary.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enerdat.IOTLibrary.Workers
{
    /// <summary>
    /// Worker class.
    /// </summary>
    public class Worker : BaseWorker, IWorker
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="workerParameters">Worker parameters <seealso cref="IWorker.Parameters"/>.</param>
        public Worker(List<Dictionary<string, dynamic>> workerParameters)
        {
            Parameters = workerParameters;
        }

        /// <inheritdoc/>
        public List<Dictionary<string, dynamic>> Parameters { get; set; }

        /// <inheritdoc/>
        public void Run()
        {
            logger.Info($"Run worker with {Parameters.Count} step(s).");
            var processesResults = new ConcurrentBag<IProcessResults>();
            foreach (var stepParameters in Parameters)
            {
                logger.Info($"Step contain {stepParameters.Count} processes.");
                Parallel.ForEach(stepParameters, (processParameters, state) =>
                {
                    logger.Debug($"Find process by name '{processParameters.Key}'.");
                    // Find process by name.
                    var procesProp = ProcessFinder.FindProcess(processParameters.Key);

                    // Create an instance of process parameters.
                    logger.Debug($"Create an instance of {nameof(procesProp.ParametersType)} process parameters.");
                    var processParamsInstance = (IProcessParameters)Activator.CreateInstance(procesProp.ParametersType, new[] { processParameters.Value });
                    // For Send to RabbitMQ parameters, set process results of previous processes as data.
                    if (processParamsInstance is SendToRabitMQParameters sendToRabitMQParameters)
                    {
                        logger.Debug($"Set data to {nameof(SendToRabitMQParameters)}, {processesResults.Count} item(s).");
                        sendToRabitMQParameters.Data = processesResults.ToArray();
                    }

                    // Create an instance of process with argument - process parameters.
                    logger.Debug($"Create an instance of {procesProp.ProcessType.Name} process with argument - process parameters.");
                    var processInstance = (IProcess)Activator.CreateInstance(procesProp.ProcessType, new[] { processParamsInstance });

                    // Start process.
                    logger.Info($"Start process {procesProp.ProcessType.Name}.");
                    var processResults = processInstance.Start();

                    // Handle process results.
                    logger.Info($"{processParameters.Key} process results: {(processResults is null ? "null" : "has value")}.");
                    if (processResults is SendToRabitMQResults sendToRabitMQResults)
                    {
                        // If data pushed to Rabit MQ successfully end worker otherwise throw an exception.
                        if (sendToRabitMQResults.PushDataSuccessful)
                        {
                            logger.Debug("Data pushed to Rabit MQ successfully, complete the worker.");
                            state.Break();
                        }
                        else
                        {
                            logger.Debug("Data pushed to Rabit MQ unsuccessfully, throw an exception.");

                            throw new Exception("Data was not pushed in Rabbit MQ!");
                        }
                    }
                    else if (processResults != null && (processResults is DataFromIOTResults || processResults is DataFromAPIResults))
                    {
                        // If process results are results of data from API, IOT push results to array to push them in Rabbit MQ at the end.
                        logger.Debug("Process results is data type, add results to processes results to push in Rabbit MQ.");
                        processesResults.Add(processResults);
                    }
                });
            }
        }
    }
}
