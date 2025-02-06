namespace Project8FoodMartProjectWithMongoDB.Dtos.CategoryDtos
{
    public class GetByIdCategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryImageURL { get; set; }
        public string CategoryIconURL { get; set; }
        public string CategoryURL { get; set; }
    }
}
