using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Project8FoodMartProjectWithMongoDB.Dtos.FeatureDtos;
using Project8FoodMartProjectWithMongoDB.Dtos.ProductDtos;
using Project8FoodMartProjectWithMongoDB.Entities;
using Project8FoodMartProjectWithMongoDB.Settings;

namespace Project8FoodMartProjectWithMongoDB.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string productId)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == productId);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfBaharatCesitleriCategoryAsync()
        {
            var category = await _categoryCollection.Find(x => x.CategoryName == "Baharat Çeşitleri").FirstOrDefaultAsync();
            if (category == null)
                return new List<ResultProductWithCategoryDto>();

            var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
            foreach (var product in products)
            {
                product.Category = category;
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfIcecekCategoryAsync()
        {
            var category = await _categoryCollection.Find(x => x.CategoryName == "İçecek").FirstOrDefaultAsync();
            if (category == null)
                return new List<ResultProductWithCategoryDto>();

            var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
            foreach (var product in products)
            {
                product.Category = category;
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfKonserveCategoryAsync()
        {
            var category = await _categoryCollection.Find(x => x.CategoryName == "Konserve").FirstOrDefaultAsync();
            if (category == null)
                return new List<ResultProductWithCategoryDto>();

            var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
            foreach (var product in products)
            {
                product.Category = category;
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfSebzeMeyveCategoryAsync()
        {
            var category = await _categoryCollection.Find(x => x.CategoryName == "Sebze & Meyve").FirstOrDefaultAsync();
            if (category == null)
                return new List<ResultProductWithCategoryDto>();

            var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
            foreach (var product in products)
            {
                product.Category = category;
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfSekerlemelerCategoryAsync()
        {
            var category = await _categoryCollection.Find(x => x.CategoryName == "Şekerlemeler").FirstOrDefaultAsync();
            if (category == null)
                return new List<ResultProductWithCategoryDto>();

            var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
            foreach (var product in products)
            {
                product.Category = category;
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfSutUrunleriCategoryAsync()
        {
            var category = await _categoryCollection.Find(x => x.CategoryName == "Süt Ürünleri").FirstOrDefaultAsync();
            if (category == null)
                return new List<ResultProductWithCategoryDto>();

            var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
            foreach (var product in products)
            {
                product.Category = category;
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfUnluMamullerCategoryAsync()
        {
            var category = await _categoryCollection.Find(x => x.CategoryName == "Unlu Mamüller").FirstOrDefaultAsync();
            if (category == null)
                return new List<ResultProductWithCategoryDto>();

            var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
            foreach (var product in products)
            {
                product.Category = category;
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductOfYagCategoryAsync()
        {
            var category = await _categoryCollection.Find(x => x.CategoryName == "Yağ").FirstOrDefaultAsync();
            if (category == null)
                return new List<ResultProductWithCategoryDto>();

            var products = await _productCollection.Find(x => x.CategoryId == category.CategoryId).ToListAsync();
            foreach (var product in products)
            {
                product.Category = category;
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string productId)
        {
            var values = await _productCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetLast10ProductsWithCategoryAsync()
        {
            var products = await _productCollection
                .Find(x => true)
                .SortByDescending(x => x.ProductId)
                .Limit(10)
                .ToListAsync();

            var categoryIds = products.Select(p => p.CategoryId).Distinct().ToList();
            var categories = await _categoryCollection
                .Find(c => categoryIds.Contains(c.CategoryId))
                .ToListAsync();

            var categoryDict = categories.ToDictionary(c => c.CategoryId, c => c);

            foreach (var product in products)
            {
                product.Category = categoryDict.GetValueOrDefault(product.CategoryId);
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task<List<ResultProductWithCategoryDto>> SearchProductsByNameAsync(string searchTerm)
        {
            var filter = Builders<Product>.Filter.Regex(x => x.ProductName, new BsonRegularExpression(searchTerm, "i"));
            var products = await _productCollection.Find(filter).ToListAsync();

            var categoryIds = products.Select(p => p.CategoryId).Distinct().ToList();
            var categories = await _categoryCollection.Find(c => categoryIds.Contains(c.CategoryId)).ToListAsync();
            var categoryDict = categories.ToDictionary(c => c.CategoryId, c => c);

            foreach (var product in products)
            {
                product.Category = categoryDict.GetValueOrDefault(product.CategoryId);
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
