using Project8FoodMartProjectWithMongoDB.Dtos.DiscountDtos;

namespace Project8FoodMartProjectWithMongoDB.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountDto>> GetAllDiscountAsync();
        Task<List<ResultDiscountWithProductOrCategoryDto>> GetAllDiscountWithProductOrCategoryDtoAsync();
        Task<List<ResultDiscountWithProductOrCategoryDto>> GetRandom2DiscountWithCategoryDtoAsync();
        Task<List<ResultDiscountWithProductOrCategoryDto>> GetRandom2DiscountWithProductDtoAsync();
        Task CreateDiscountAsync(CreateDiscountDto createDiscountDto);
        Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto);
        Task DeleteDiscountAsync(string discountId);
        Task<GetByIdDiscountDto> GetByIdDiscountAsync(string discountId);
    }
}
