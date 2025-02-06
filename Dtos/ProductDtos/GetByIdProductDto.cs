namespace Project8FoodMartProjectWithMongoDB.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public string UnitType { get; set; }
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
    }
}
