using Microsoft.AspNetCore.Mvc;
using Project8FoodMartProjectWithMongoDB.Services.FeatureServices;

namespace Project8FoodMartProjectWithMongoDB.ViewComponents
{
    public class _DefaultFeature : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _DefaultFeature(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var features = await _featureService.GetAllFeatureAsync();
            return View(features);
        }
    }
}
