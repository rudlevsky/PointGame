using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPointGame.GenericTypes
{
    /// <summary>
    /// Minimal realization which message should have.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Message<TContent>
    {
        /// <summary>
        /// A container which has our message data.
        /// </summary>
        public TContent Content { get; }

        public Message(TContent data)
        {
            Content = data;
        }
    }
}
