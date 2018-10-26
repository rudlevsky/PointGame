using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPointGame.GenericTypes;

namespace FPointGame.Interfaces
{
    /// <summary>
    /// Represents all methods which Publisher has.
    /// </summary>
    public interface IPublisher<TContent>
    {
        /// <summary>
        /// Publish a message about itself.
        /// </summary>
        /// <param name="medium"></param>
        void Publish(Message<TContent> message);
    }
}
