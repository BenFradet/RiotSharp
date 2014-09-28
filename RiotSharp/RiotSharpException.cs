// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RiotSharpException.cs" company="">
//   
// </copyright>
// <summary>
//   RiotSharp exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace RiotSharp
{
    /// <summary>
    /// RiotSharp exception.
    /// </summary>
    public class RiotSharpException: Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RiotSharpException"/> class.
        /// </summary>
        public RiotSharpException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RiotSharpException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public RiotSharpException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RiotSharpException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="inner">
        /// The inner.
        /// </param>
        public RiotSharpException(string message, Exception inner)
            : base(message, inner) { }
    }
}
