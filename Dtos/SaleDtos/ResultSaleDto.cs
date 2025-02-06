namespace Project8FoodMartProjectWithMongoDB.Dtos.SaleDtos
{
    public class ResultSaleDto
    {
        public string SaleId { get; set; }
        public string ProductId { get; set; }
        public int NumberOfProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
