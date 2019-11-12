using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ValrCore
{
    /// <summary>
    /// Response from Valr API.
    /// </summary>
    /// <typeparam name="T">Type of result.</typeparam>
    public class ValrResponse<T>
    {
        /// <summary>
        /// Gets or sets errors of a request.
        /// </summary>
        [JsonProperty("error")]
        public ReadOnlyCollection<ErrorString> Errors { get; set; }

        /// <summary>
        /// Gets or sets the result of a request.
        /// </summary>
        public T Result { get; set; } // Nullable

        /// <summary>
        /// Gets or sets the raw Json result of a request.
        /// </summary>
        public string RawJson { get; set; }
    }
}
