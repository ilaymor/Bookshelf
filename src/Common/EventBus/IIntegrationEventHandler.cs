namespace IlayMor.Bookshelf.Common.EventBus;

public interface IIntegrationEventHandler<TEvent> where TEvent : IIntegrationEvent
{
    Task Handle(TEvent @event);
}