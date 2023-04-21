namespace IlayMor.Bookshelf.Common.EventBus.Abstractions;

public interface IIntegrationEvent
{
    Guid EventID { get; }
    DateTime CreationDate { get; }
}