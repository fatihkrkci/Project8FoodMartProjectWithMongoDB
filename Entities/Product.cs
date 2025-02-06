using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Project8FoodMartProjectWithMongoDB.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string UnitType { get; set; }
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
