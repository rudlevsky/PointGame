using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPointGame.GenericTypes;

namespace FPointGame.Interfaces
{
    /// <summary>
    /// Represents all methods which Medium has.
    /// </summary>
    public interface IChannel<TContent>
    {
        /// <summary>
        /// Notify all subscribers about message.
        /// </summary>
        void NotifyAll(Message<TContent> message);

        void AddSubscriber(ISubscriber<TContent> subscriber);
        void RemoveSubscriber(ISubscriber<TContent> subscriber);
    }
}
