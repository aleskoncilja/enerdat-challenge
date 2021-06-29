using Enerdat.IOTLibrary.Models.ProcessResults;

namespace Enerdat.IOTLibrary.Providers
{
    /// <summary>
    /// Rabbit MQ provider interface.
    /// </summary>
    public interface IRabbitMQProvider
    {
        /// <summary>
        /// Push data into Rabit MQ.
        /// </summary>
        /// <param name="data">Array of process results objects.</param>
        void Push(IProcessResults[] data);
    }
}
