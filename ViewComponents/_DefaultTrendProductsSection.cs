using Microsoft.AspNetCore.Mvc;
using Project8FoodMartProjectWithMongoDB.Services.FeatureServices;
using Project8FoodMartProjectWithMongoDB.Services.ProductServices;

namespace Project8FoodMartProjectWithMongoDB.ViewComponents
{
    public class _DefaultTrendProductsSection : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultTrendProductsSection(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var last10Products = await _productService.GetLast10ProductsWithCategoryAsync();
            return View(last10Products);
        }
    }
}
