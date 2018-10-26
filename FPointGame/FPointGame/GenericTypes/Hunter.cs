using System;
using FPointGame.Interfaces;

namespace FPointGame.GenericTypes
{
    /// <summary>
    /// Class implements interace IPublisher.
    /// </summary>
    /// <typeparam name="TContent">Type of the content.</typeparam>
    public class Hunter<TContent> : IPublisher<TContent>
    {
        private TContent data;
        private IChannel<TContent> channel;
        private readonly bool isClass = typeof(TContent).IsClass;

        /// <summary>
        /// Property gives access to field data.
        /// </summary>
        public TContent Content
        {
            get { return data; }
            set
            {
                if (isClass && (value == null)) throw new ArgumentNullException(nameof(value));

                Publish(new Message<TContent>(value));
                data = value;
            }
        }

        /// <summary>
        /// Class's constructor.
        /// </summary>
        /// <param name="medium">Passed data.</param>
        public Hunter(IChannel<TContent> medium)
        {
            this.channel = channel ?? throw new ArgumentNullException(nameof(medium));
        }

        /// <summary>
        /// Method puts data into channel.
        /// </summary>
        /// <param name="message">Passed data.</param>
        public void Publish(Message<TContent> message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

			channel.NotifyAll(message);
        }
    }
}
