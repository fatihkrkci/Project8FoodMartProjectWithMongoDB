using Microsoft.AspNetCore.Mvc;
using Project8FoodMartProjectWithMongoDB.Dtos.CategoryDtos;
using Project8FoodMartProjectWithMongoDB.Dtos.DiscountDtos;
using Project8FoodMartProjectWithMongoDB.Services.CategoryServices;
using Project8FoodMartProjectWithMongoDB.Services.DiscountServices;
using Project8FoodMartProjectWithMongoDB.Services.ProductServices;

namespace Project8FoodMartProjectWithMongoDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public DiscountController(IDiscountService discountService, ICategoryService categoryService, IProductService productService)
        {
            _discountService = discountService;
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateDiscount()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            var products = await _productService.GetAllProductAsync();

            ViewBag.Categories = categories;
            ViewBag.Products = products;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            await _discountService.CreateDiscountAsync(createDiscountDto);
            return RedirectToAction("DiscountList");
        }

        public async Task<IActionResult> DiscountList()
        {
            var values = await _discountService.GetAllDiscountWithProductOrCategoryDtoAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteDiscount(string id)
        {
            await _discountService.DeleteDiscountAsync(id);
            return RedirectToAction("DiscountList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(string id)
        {
            var discount = await _discountService.GetByIdDiscountAsync(id);

            var categories = await _categoryService.GetAllCategoryAsync();
            var products = await _productService.GetAllProductAsync();

            ViewBag.Categories = categories;
            ViewBag.Products = products;

            return View(discount);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            await _discountService.UpdateDiscountAsync(updateDiscountDto);
            return RedirectToAction("DiscountList");
        }
    }
}
