using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Project8FoodMartProjectWithMongoDB.Entities
{
    public class Sale
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SaleId { get; set; }
        public int NumberOfProducts { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalPrice { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
