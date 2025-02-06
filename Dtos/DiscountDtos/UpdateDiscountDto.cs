namespace Project8FoodMartProjectWithMongoDB.Dtos.DiscountDtos
{
    public class UpdateDiscountDto
    {
        public string DiscountId { get; set; }
        public string? CategoryId { get; set; }
        public string? ProductId { get; set; }
        public int DiscountRate { get; set; }
    }
}
