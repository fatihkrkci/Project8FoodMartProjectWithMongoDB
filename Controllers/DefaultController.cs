using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Project8FoodMartProjectWithMongoDB.Dtos.ProductDtos;
using Project8FoodMartProjectWithMongoDB.Services.ProductServices;

namespace Project8FoodMartProjectWithMongoDB.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProductService _productService;
        private readonly IConfiguration _configuration;

        public DefaultController(IProductService productService, IConfiguration configuration)
        {
            _productService = productService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllProducts(string searchTerm)
        {
            List<ResultProductWithCategoryDto> allProducts;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                allProducts = await _productService.SearchProductsByNameAsync(searchTerm);
            }
            else
            {
                allProducts = await _productService.GetAllProductWithCategoryAsync();
            }

            return View(allProducts);
        }

        public async Task<IActionResult> UnluMamuller()
        {
            var products = await _productService.GetAllProductOfUnluMamullerCategoryAsync();
            return View(products);
        }

        public async Task<IActionResult> SebzeMeyve()
        {
            var products = await _productService.GetAllProductOfSebzeMeyveCategoryAsync();
            return View(products);
        }

        public async Task<IActionResult> SutUrunleri()
        {
            var products = await _productService.GetAllProductOfSutUrunleriCategoryAsync();
            return View(products);
        }

        public async Task<IActionResult> Yag()
        {
            var products = await _productService.GetAllProductOfYagCategoryAsync();
            return View(products);
        }

        public async Task<IActionResult> Sekerlemeler()
        {
            var products = await _productService.GetAllProductOfSekerlemelerCategoryAsync();
            return View(products);
        }

        public async Task<IActionResult> Konserve()
        {
            var products = await _productService.GetAllProductOfKonserveCategoryAsync();
            return View(products);
        }

        public async Task<IActionResult> BaharatCesitleri()
        {
            var products = await _productService.GetAllProductOfBaharatCesitleriCategoryAsync();
            return View(products);
        }

        public async Task<IActionResult> Icecek()
        {
            var products = await _productService.GetAllProductOfIcecekCategoryAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(string name, string email, string message)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("FoodMart", smtpSettings["SenderEmail"]));
            emailMessage.To.Add(new MailboxAddress(name, email));
            emailMessage.Subject = "FoodMart İndirim Kodunuz";
            emailMessage.Body = new TextPart("plain") { Text = $"Merhaba {name},\n\n{message}" };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpSettings["Server"], int.Parse(smtpSettings["Port"]), false);
                await client.AuthenticateAsync(smtpSettings["SenderEmail"], smtpSettings["SenderPassword"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }

            return RedirectToAction("Index");
        }
    }
}
