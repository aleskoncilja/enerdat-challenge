using Enerdat.IOTLibrary.Attributes;
using Enerdat.IOTLibrary.Processes;
using NLog;
using System;

namespace Enerdat.IOTLibrary.Services
{
    /// <summary>
    /// Service class - Process finder.
    /// </summary>
    public static class ProcessFinder
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get process and parameters types by process name.
        /// </summary>
        /// <param name="name">Process name.</param>
        /// <returns>Process and process parameters type.</returns>
        public static (Type ProcessType, Type ParametersType) FindProcess(string name)
        {
            logger.Debug($"Find process by name '{name}' and return process type and parameters type of process.");

            foreach (var type in typeof(IProcess).Assembly.GetTypes())
            {
                var attributes = type.GetCustomAttributes(typeof(ProcessNameAttribute), true);
                if (attributes.Length > 0)
                {
                    var processAttribute = (ProcessNameAttribute)attributes[0];
                    if (processAttribute.Name == name)
                    {
                        return (type, processAttribute.ParametersType);
                    }
                }
            }

            throw new Exception($"Process '{name}' not exists!");
        }
    }
}
