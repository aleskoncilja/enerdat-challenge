using System.Collections.Generic;

namespace Enerdat.IOTLibrary.Workers
{
    /// <summary>
    /// Worker interface.
    /// </summary>
    public interface IWorker
    {
        /// <summary>
        /// Worker parameters. List of steps that contains one or more processes with parameters json value. Steps run sequentialy, defined processes in for each steps as dictionary run in parallel.
        /// </summary>
        List<Dictionary<string, dynamic>> Parameters { get; set; }

        /// <summary>
        /// Run worker.
        /// </summary>
        void Run();
    }
}
