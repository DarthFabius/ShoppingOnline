using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace ShoppingOnLine.EventBus.RabbitMQ
{
    public interface IRabbitMQPersistentConnection
    {
        IConnection Connection { get; }
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
