using Enerdat.IOTLibrary.Helpers;
using Enerdat.IOTLibrary.Workers;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;

namespace Enerdat.WebApp.Controllers
{
    /// <summary>
    /// Test worker controller.
    /// </summary>
    public class TestWorkerController : Controller
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Index action.
        /// </summary>
        /// <param name="parallel">If test worker in parralel or sequential.</param>
        /// <returns></returns>
        public IActionResult Index(bool parallel = false)
        {
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

            return View(parallel);
        }
    }
}