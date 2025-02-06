using Microsoft.AspNetCore.Mvc;
using Project8FoodMartProjectWithMongoDB.Services.FeatureServices;
using Project8FoodMartProjectWithMongoDB.Services.SaleServices;

namespace Project8FoodMartProjectWithMongoDB.ViewComponents
{
    public class _DefaultMostSellerProductsSection : ViewComponent
    {
        private readonly ISaleService _saleService;

        public _DefaultMostSellerProductsSection(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mostSellers = await _saleService.GetTop6SalesWithProductAsync();
            return View(mostSellers);
        }
    }
}
