using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoreApi.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string CustomerId { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Quantity { get; set; } = 0;

}

    
