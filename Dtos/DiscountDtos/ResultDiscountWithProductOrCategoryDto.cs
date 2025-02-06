namespace Project8FoodMartProjectWithMongoDB.Dtos.DiscountDtos
{
    public class ResultDiscountWithProductOrCategoryDto
    {
        public string DiscountId { get; set; }
        public int DiscountRate { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public string? CategoryImageURL { get; set; }
        public string? ProductImageURL { get; set; }
    }
}
