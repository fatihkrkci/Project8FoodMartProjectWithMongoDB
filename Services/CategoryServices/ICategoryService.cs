using Project8FoodMartProjectWithMongoDB.Dtos.CategoryDtos;

namespace Project8FoodMartProjectWithMongoDB.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string categoryId);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId);
    }
}
