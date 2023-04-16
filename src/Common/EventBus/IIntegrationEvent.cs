namespace IlayMor.Bookshelf.Common.EventBus;

public interface IIntegrationEvent
{
    Guid EventID { get; }
    DateTime CreationDate { get; }
}