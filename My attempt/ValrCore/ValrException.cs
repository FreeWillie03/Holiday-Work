using System;
using System.Collections.ObjectModel;

namespace ValrCore
{
    /// <summary>
    /// Represents errors that occur at Valr API level.
    /// </summary>
    public class ValrException : Exception
    {
        public ValrException(ReadOnlyCollection<ErrorString> errors, string message)
            : base(message)
        {
            Errors = errors;
        }

        /// <summary>
        /// Gets the errors returned by Valr API.
        /// </summary>
        public ReadOnlyCollection<ErrorString> Errors { get; }
    }
}
