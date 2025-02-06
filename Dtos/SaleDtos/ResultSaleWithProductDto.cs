namespace Project8FoodMartProjectWithMongoDB.Dtos.SaleDtos
{
    public class ResultSaleWithProductDto
    {
        public string SaleId { get; set; }
        public int NumberOfProducts { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
        public string UnitType { get; set; }
        public string Price { get; set; }
        public string ProductImageURL { get; set; }
    }
}
