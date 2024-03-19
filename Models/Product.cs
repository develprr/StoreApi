
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoreApi.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string CustomerId { get; set; } = null!;

    public decimal Category { get; set; }

    public decimal Name { get; set; }

    public string Quantity { get; set; } = null!;

}

    
