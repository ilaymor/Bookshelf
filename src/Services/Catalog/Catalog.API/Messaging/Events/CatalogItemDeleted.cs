namespace IlayMor.Bookshelf.Services.Catalog.API.Messaging.Events;

public interface CatalogItemDeleted
{
    public Guid ItemId { get; set; }
}