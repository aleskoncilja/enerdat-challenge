namespace Enerdat.IOTLibrary.Models.ProcessResults
{
    /// <summary>
    /// Send to Rabbit MQ results class.
    /// </summary>
    public class SendToRabitMQResults : IProcessResults
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pushDataSuccessful">Pushed data successfully.</param>
        public SendToRabitMQResults(bool pushDataSuccessful)
        {
            PushDataSuccessful = pushDataSuccessful;
        }

        /// <summary>
        /// If data pushed to Rabbit MQ successfully.
        /// </summary>
        public bool PushDataSuccessful { get; set; }
    }
}
