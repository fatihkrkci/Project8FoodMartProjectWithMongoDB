using Project8FoodMartProjectWithMongoDB.Dtos.ProductDtos;

namespace Project8FoodMartProjectWithMongoDB.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetLast10ProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> SearchProductsByNameAsync(string searchTerm);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string productId);
        Task<GetByIdProductDto> GetByIdProductAsync(string productId);
        Task<List<ResultProductWithCategoryDto>> GetAllProductOfUnluMamullerCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductOfSebzeMeyveCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductOfSutUrunleriCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductOfYagCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductOfSekerlemelerCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductOfKonserveCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductOfBaharatCesitleriCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductOfIcecekCategoryAsync();
    }
}
