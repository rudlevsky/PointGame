using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPointGame.Interfaces;

namespace FPointGame.GenericTypes
{
    public class Hunter<TContent> : IPublisher<TContent>
    {
        TContent data;
        private IChannel<TContent> medium;
        private readonly bool IsClass = typeof(TContent).IsClass;

        public TContent Content
        {
            get { return data; }
            set
            {
                if (IsClass && (value == null)) throw new ArgumentNullException(nameof(value));

                Publish(new Message<TContent>(value));
                data = value;
            }
        }

        public Hunter(IChannel<TContent> medium)
        {
            this.medium = medium ?? throw new ArgumentNullException(nameof(medium));
        }

        public void Publish(Message<TContent> message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            medium.NotifyAll(message);
        }
    }
}
