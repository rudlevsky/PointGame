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
        /// <param name="message">Passed message.</param>
        void NotifyAll(Message<TContent> message);

        /// <summary>
        /// Adds new subscriber.
        /// </summary>
        /// <param name="subscriber">New subscriber.</param>
        void AddSubscriber(ISubscriber<TContent> subscriber);

        /// <summary>
        /// Removes subscriber.
        /// </summary>
        /// <param name="subscriber">Subscriber for removing.</param>
        void RemoveSubscriber(ISubscriber<TContent> subscriber);
    }
}
