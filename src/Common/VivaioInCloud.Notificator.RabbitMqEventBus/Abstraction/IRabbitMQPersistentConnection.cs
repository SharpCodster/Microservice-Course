using RabbitMQ.Client;

namespace VivaioInCloud.Notificator.RabbitMqEventBus.Abstraction
{
    public interface IRabbitMQPersistentConnection
    : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
