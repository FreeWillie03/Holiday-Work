using Newtonsoft.Json;

namespace ValrCore.Models
{
    public class AddOrderResult
    {
        /// <summary>
        /// Order description info.
        /// </summary>
        [JsonProperty("descr")]
        public AddOrderDescription Description { get; set; }

        /// <summary>
        /// Array of transaction ids for order (if order was added successfully).
        /// </summary>
        [JsonProperty("txid")]
        public string[] TransactionIds { get; set; }
    }

    public class AddOrderDescription
    {
        
        public string Order { get; set; }

        public string Close { get; set; }
    }
}
