namespace Project8FoodMartProjectWithMongoDB.Dtos.DiscountDtos
{
    public class CreateDiscountDto
    {
        public string? CategoryId { get; set; }
        public string? ProductId { get; set; }
        public int DiscountRate { get; set; }
    }
}
