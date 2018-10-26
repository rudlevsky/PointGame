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
        /// <param name="message">Passed message.</param>
        void Publish(Message<TContent> message);
    }
}
