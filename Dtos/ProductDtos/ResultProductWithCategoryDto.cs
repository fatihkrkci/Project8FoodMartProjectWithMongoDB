namespace Project8FoodMartProjectWithMongoDB.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string UnitType { get; set; }
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
        public string CategoryImageURL { get; set; }
        public string CategoryName { get; set; }
    }
}
