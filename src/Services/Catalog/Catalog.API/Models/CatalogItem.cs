using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace IlayMor.Bookshelf.Services.Catalog.API.Models;

public class CatalogItem
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid ItemId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}