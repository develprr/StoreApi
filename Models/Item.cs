
        
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    namespace StoreApi.Models;

    public class StoreApi
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string ItemName { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal Weight { get; set; }

        public string Category { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
  
      
