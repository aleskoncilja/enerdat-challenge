namespace Enerdat.IOTLibrary.Models.ProcessResults
{
    /// <summary>
    /// Data from API results class.
    /// </summary>
    public class DataFromAPIResults : IProcessResults
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ip">IP.</param>
        /// <param name="id">Device id.</param>
        /// <param name="tags">Array of tags.</param>
        /// <param name="description">Description.</param>
        public DataFromAPIResults(string ip, string id, string[] tags, string description)
        {
            Ip = ip;
            Id = id;
            Tags = tags;
            Description = description;
        }

        /// <summary>
        /// IP.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// Device id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Tags.
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }
    }
}
