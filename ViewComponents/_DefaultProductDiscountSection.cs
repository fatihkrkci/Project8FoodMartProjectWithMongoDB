using Microsoft.AspNetCore.Mvc;
using Project8FoodMartProjectWithMongoDB.Services.DiscountServices;

namespace Project8FoodMartProjectWithMongoDB.ViewComponents
{
    public class _DefaultProductDiscountSection : ViewComponent
    {
        private readonly IDiscountService _discountService;

        public _DefaultProductDiscountSection(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var discounts = await _discountService.GetRandom2DiscountWithProductDtoAsync();
            return View(discounts);
        }
    }
}
