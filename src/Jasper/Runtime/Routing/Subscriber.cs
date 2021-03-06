using System;
using System.Collections.Generic;
using System.Linq;
using Jasper.Transports;

namespace Jasper.Runtime.Routing
{
    public abstract class Subscriber : ISubscriber
    {
        public IList<Subscription> Subscriptions { get; } = new List<Subscription>();

        /// <summary>
        ///     Mark whether or not the receiver for this listener should use
        ///     message persistence for durability
        /// </summary>
        public bool IsDurable { get; set; }

        public bool ShouldSendMessage(Type messageType)
        {
            return Subscriptions.Any(x => x.Matches(messageType));
        }

        public abstract void AddRoute(MessageTypeRouting routing, IMessagingRoot root);
    }
}
