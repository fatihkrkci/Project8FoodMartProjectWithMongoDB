using Project8FoodMartProjectWithMongoDB.Dtos.FeatureDtos;

namespace Project8FoodMartProjectWithMongoDB.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string featureId);
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string featureId);
    }
}
