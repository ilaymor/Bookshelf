namespace IlayMor.Bookshelf.Common.EventBus;

using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RabbitMqEventBus : IEventBus, IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqEventBus(string hostName, string userName, string password)
    {
        var factory = new ConnectionFactory { HostName = hostName, UserName = userName, Password = password };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void Publish<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
    {
        var eventName = @event.GetType().Name;
        _channel.QueueDeclare(queue: eventName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var message = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "", routingKey: eventName, basicProperties: null, body: body);
    }

    public void Subscribe<TEvent, TEventHandler>()
        where TEvent : IIntegrationEvent
        where TEventHandler : IIntegrationEventHandler<TEvent>, new()
    {
        var eventName = typeof(TEvent).Name;
        _channel.QueueDeclare(queue: eventName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var message = Encoding.UTF8.GetString(ea.Body.Span);
            var integrationEvent = JsonConvert.DeserializeObject<TEvent>(message);

            var handler = new TEventHandler();
            await handler.Handle(integrationEvent);
        };

        _channel.BasicConsume(queue: eventName, autoAck: true, consumer: consumer);
    }

    public void Unsubscribe<TEvent, TEventHandler>()
        where TEvent : IIntegrationEvent
        where TEventHandler : IIntegrationEventHandler<TEvent>
    {
        // Unsubscriwbing can be implemented according to your requirements.
        // For example, you can maintain a list of event handlers and remove the specified handler from the list.
        // For simplicity, this example does not include an unsubscribe implementation.
    }

    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}
