using Microsoft.AspNetCore.Mvc;
using Project8FoodMartProjectWithMongoDB.Services.CategoryServices;
using Project8FoodMartProjectWithMongoDB.Services.FeatureServices;

namespace Project8FoodMartProjectWithMongoDB.ViewComponents
{
    public class _DefaultCategorySection : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultCategorySection(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);
        }
    }
}
