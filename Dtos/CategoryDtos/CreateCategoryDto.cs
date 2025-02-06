namespace Project8FoodMartProjectWithMongoDB.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public string? CategoryImageURL { get; set; }
        public string CategoryIconURL { get; set; }
        public string CategoryURL { get; set; }
    }
}
