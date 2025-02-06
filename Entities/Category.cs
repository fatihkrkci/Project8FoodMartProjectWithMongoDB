using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project8FoodMartProjectWithMongoDB.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryImageURL { get; set; }
        public string CategoryIconURL { get; set; }
        public string CategoryURL { get; set; }
    }
}
