using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ShoppingOnLine.EventBus.RabbitMQ
{
    public class DefaultRabbitMQPersistentConnection : IRabbitMQPersistentConnection, IDisposable
    {
        private IConnectionFactory _connectionFactory;
        private ILogger<DefaultRabbitMQPersistentConnection> _logger;

        object sync_root = new object();

        public DefaultRabbitMQPersistentConnection(IConnectionFactory connectionFactory, ILogger<DefaultRabbitMQPersistentConnection> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public bool IsConnected => Connection?.IsOpen ?? false;

        public IConnection Connection { get; private set; } 

        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Connection to RabbitMQ not availabe");
            }

            return Connection.CreateModel();
        }

        public void Dispose()
        {
            try
            {
                Connection.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.ToString());
            }
        }

        public bool TryConnect()
        {
            _logger.LogInformation("RabbitMQ Client is trying to connect");

            lock (sync_root)
            {
                Connection = _connectionFactory.CreateConnection();
              
                if (IsConnected)
                {
                    Connection.ConnectionShutdown += OnConnectionShutdown;
                    Connection.CallbackException += OnCallbackException;
                    Connection.ConnectionBlocked += OnConnectionBlocked;

                    _logger.LogInformation($"RabbitMQ persistent connection acquired a connection { Connection.Endpoint.HostName} and is subscribed to failure events");

                    return true;
                }
                else
                {
                    _logger.LogCritical("FATAL ERROR: RabbitMQ connections could not be created and opened");
                    return false;
                }
            }
        }

        private void OnConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        {
            _logger.LogWarning("A RabbitMQ connection is shutdown. Trying to re-connect...");
            TryConnect();
        }

        void OnCallbackException(object sender, CallbackExceptionEventArgs e)
        {
            _logger.LogWarning("A RabbitMQ connection throw exception. Trying to re-connect...");

            TryConnect();
        }

        void OnConnectionShutdown(object sender, ShutdownEventArgs reason)
        {
            _logger.LogWarning("A RabbitMQ connection is on shutdown. Trying to re-connect...");

            TryConnect();
        }

    }
}
