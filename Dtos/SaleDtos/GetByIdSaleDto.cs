namespace Project8FoodMartProjectWithMongoDB.Dtos.SaleDtos
{
    public class GetByIdSaleDto
    {
        public string SaleId { get; set; }
        public string ProductId { get; set; }
        public int NumberOfProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
