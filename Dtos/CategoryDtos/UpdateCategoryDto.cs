namespace Project8FoodMartProjectWithMongoDB.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryImageURL { get; set; }
        public string CategoryIconURL { get; set; }
        public string CategoryURL { get; set; }
    }
}
