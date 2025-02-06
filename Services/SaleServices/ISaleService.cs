using Project8FoodMartProjectWithMongoDB.Dtos.ProductDtos;
using Project8FoodMartProjectWithMongoDB.Dtos.SaleDtos;

namespace Project8FoodMartProjectWithMongoDB.Services.SaleServices
{
    public interface ISaleService
    {
        Task<List<ResultSaleDto>> GetAllSaleAsync();
        Task<List<ResultSaleWithProductDto>> GetAllSalesWithProductAsync();
        Task<List<ResultSaleWithProductDto>> GetTop6SalesWithProductAsync();
        Task CreateSaleAsync(CreateSaleDto createSaleDto);
        Task UpdateSaleAsync(UpdateSaleDto updateSaleDto);
        Task DeleteSaleAsync(string saleId);
        Task<GetByIdSaleDto> GetByIdSaleAsync(string saleId);
    }
}
