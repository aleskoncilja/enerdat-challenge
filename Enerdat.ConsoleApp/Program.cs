using Enerdat.IOTLibrary.Helpers;
using Enerdat.IOTLibrary.Workers;
using NLog;
using System;
using System.Collections.Generic;

namespace Enerdat.ConsoleApp
{
    /// <summary>
    /// Program (main) class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Arguments.</param>
        static void Main(string[] args)
        {
            // Read user command how to simulate worker.
            Console.WriteLine("Hello World!");
            Console.WriteLine("Press 'y' to run worker in parallel:");
            var parallel = Console.ReadLine()?.ToLower() == "y";


            // Get worker parameters.
            List<Dictionary<string, dynamic>> workerParameters = null;
            try
            {
                _logger.Debug($"Generate worker parameters; {nameof(parallel)}={parallel}.");
                if (parallel)
                {
                    workerParameters = WorkerHelper.GenerateParallelWorkerParameters();
                }
                else
                {
                    workerParameters = WorkerHelper.GenerateSequentialWorkerParameters();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occured while generating worker parameters.");
            }

            if (workerParameters != null)
            {
                try
                {
                    _logger.Debug("Create new instance of worker with paramers.");
                    // Create new instance of worker with paramers.
                    var worker = new Worker(workerParameters);

                    // Run worker.
                    _logger.Debug("Run worker.");
                    worker.Run();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "An error occured while running worker.");
                }
            }

            Console.WriteLine("Press 'Enter' to exit!");
            Console.ReadLine();
        }
    }
}
