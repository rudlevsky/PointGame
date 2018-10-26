using System;
using System.Collections.Generic;
using FPointGame.Interfaces;

namespace FPointGame.GenericTypes
{
    /// <summary>
    /// Class implements interface IChannel.
    /// </summary>
    /// <typeparam name="TContent">Type of the data.</typeparam>
    public class Channel<TContent> : IChannel<TContent>
    {
        private List<ISubscriber<TContent>> subsList = new List<ISubscriber<TContent>>();

        /// <summary>
        /// Method notifies all subscribers.
        /// </summary>
        /// <param name="message">Passed data.</param>
        public void NotifyAll(Message<TContent> message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            for (int i = 0; i < subsList.Count; i++)
            {
                subsList[i].Update(new Message<TContent>(message.Content));
            }

            message.Dispose();
        }

        /// <summary>
        /// Method adds new subscriber.
        /// </summary>
        /// <param name="subscriber">New subscriber.</param>
        public void AddSubscriber(ISubscriber<TContent> subscriber)
        {
            subsList.Add(subscriber);
        }

        /// <summary>
        /// Method removes passed subscriber.
        /// </summary>
        /// <param name="subscriber">Passed subscriber.</param>
        public void RemoveSubscriber(ISubscriber<TContent> subscriber)
        {
            subsList.Remove(subscriber);
        }
    }
}
