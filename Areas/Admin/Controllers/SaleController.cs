using Microsoft.AspNetCore.Mvc;
using Project8FoodMartProjectWithMongoDB.Dtos.SaleDtos;
using Project8FoodMartProjectWithMongoDB.Services.ProductServices;
using Project8FoodMartProjectWithMongoDB.Services.SaleServices;

namespace Project8FoodMartProjectWithMongoDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IProductService _productService;

        public SaleController(ISaleService saleService, IProductService productService)
        {
            _saleService = saleService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateSale()
        {
            var products = await _productService.GetAllProductAsync();

            ViewBag.Products = products.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.Price
            });

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSale(CreateSaleDto createSaleDto)
        {
            if (!ModelState.IsValid)
            {
                var products = await _productService.GetAllProductAsync();
                ViewBag.Products = products;
                return View(createSaleDto);
            }

            createSaleDto.TotalPrice = Math.Round(createSaleDto.TotalPrice, 2);

            Console.WriteLine($"TotalPrice: {createSaleDto.TotalPrice}");

            await _saleService.CreateSaleAsync(createSaleDto);
            return RedirectToAction("SaleList");
        }



        public async Task<IActionResult> SaleList()
        {
            var values = await _saleService.GetAllSalesWithProductAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteSale(string id)
        {
            await _saleService.DeleteSaleAsync(id);
            return RedirectToAction("SaleList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSale(string id)
        {
            var products = await _productService.GetAllProductAsync();

            ViewBag.Products = products.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.Price
            });

            var value = await _saleService.GetByIdSaleAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSale(UpdateSaleDto updateSaleDto)
        {
            await _saleService.UpdateSaleAsync(updateSaleDto);
            return RedirectToAction("SaleList");
        }
    }
}
