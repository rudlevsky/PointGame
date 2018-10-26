﻿using System;
using System.Collections.Generic;
using FPointGame.Interfaces;

namespace FPointGame.GenericTypes
{
    public class Channel<TContent> : IChannel<TContent>
    {
        private List<ISubscriber<TContent>> subsList = new List<ISubscriber<TContent>>();

        public void NotifyAll(Message<TContent> message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            for (int i = 0; i < subsList.Count; i++)
            {
                subsList[i].Update(new Message<TContent>(message.Content));
            }

            message.Dispose();
        }

        public void AddSubscriber(ISubscriber<TContent> subscriber)
        {
            subsList.Add(subscriber);
        }

        public void RemoveSubscriber(ISubscriber<TContent> subscriber)
        {
            subsList.Remove(subscriber);
        }
    }
}
