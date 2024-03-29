﻿using FPointGame.GenericTypes;

namespace FPointGame.Interfaces
{
    /// <summary>
    /// Represents all methods which Publisher has.
    /// </summary>
    public interface ISubscriber<TContent>
    {
        /// <summary>
        /// Update a subscriber with new message.
        /// </summary>
        /// <param name="message">The <see cref="Message{TContent}"/>.</param>
        void Update(Message<TContent> message);
    }
}
