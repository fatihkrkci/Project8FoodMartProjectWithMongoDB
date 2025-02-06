namespace Project8FoodMartProjectWithMongoDB.Dtos.SaleDtos
{
    public class CreateSaleDto
    {
        public string ProductId { get; set; }
        public int NumberOfProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
