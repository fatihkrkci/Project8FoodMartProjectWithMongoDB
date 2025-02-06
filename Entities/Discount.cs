using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Project8FoodMartProjectWithMongoDB.Entities
{
    public class Discount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DiscountId { get; set; }
        public int DiscountRate { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
