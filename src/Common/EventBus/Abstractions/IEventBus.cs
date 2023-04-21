namespace IlayMor.Bookshelf.Common.EventBus.Abstractions;

public interface IEventBus
{
    void Publish<TEvent>(TEvent @event) where TEvent : IIntegrationEvent;
    void Subscribe<TEvent, TEventHansdler>()
        where TEvent : IIntegrationEvent
        where TEventHandler : IIntegrationEventHandler<TEvent>;
    void Unubscribe<TEvent, TEventHandler>()
        where TEvent : IIntegrationEvent
        where TEventHandler : IIntegrationEventHandler<TEvent>;
}