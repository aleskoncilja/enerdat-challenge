namespace Enerdat.IOTLibrary.Models.ProcessResults
{
    /// <summary>
    /// Data from IOT results class.
    /// </summary>
    public class DataFromIOTResults : IProcessResults
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="temperature">Temperature.</param>
        public DataFromIOTResults(double temperature)
        {
            Temperature = temperature;
        }

        /// <summary>
        /// Temperature.
        /// </summary>
        public double Temperature { get; set; }
    }
}
