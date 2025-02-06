using AutoMapper;
using MongoDB.Driver;
using Project8FoodMartProjectWithMongoDB.Dtos.CategoryDtos;
using Project8FoodMartProjectWithMongoDB.Dtos.DiscountDtos;
using Project8FoodMartProjectWithMongoDB.Entities;
using Project8FoodMartProjectWithMongoDB.Settings;

namespace Project8FoodMartProjectWithMongoDB.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly IMongoCollection<Discount> _discountCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public DiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _discountCollection = database.GetCollection<Discount>(_databaseSettings.DiscountCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDiscountAsync(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            await _discountCollection.InsertOneAsync(value);
        }

        public async Task DeleteDiscountAsync(string discountId)
        {
            await _discountCollection.DeleteOneAsync(x => x.DiscountId == discountId);
        }

        public async Task<List<ResultDiscountDto>> GetAllDiscountAsync()
        {
            var values = await _discountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDiscountDto>>(values);
        }

        public async Task<List<ResultDiscountWithProductOrCategoryDto>> GetAllDiscountWithProductOrCategoryDtoAsync()
        {
            var discounts = await _discountCollection.Find(x => true).ToListAsync();

            var result = new List<ResultDiscountWithProductOrCategoryDto>();

            foreach (var discount in discounts)
            {
                Category category = null;
                if (!string.IsNullOrEmpty(discount.CategoryId))
                {
                    category = await _categoryCollection.Find(x => x.CategoryId == discount.CategoryId).FirstOrDefaultAsync();
                }

                Product product = null;
                if (!string.IsNullOrEmpty(discount.ProductId))
                {
                    product = await _productCollection.Find(x => x.ProductId == discount.ProductId).FirstOrDefaultAsync();
                }

                var discountDto = new ResultDiscountWithProductOrCategoryDto
                {
                    DiscountId = discount.DiscountId,
                    DiscountRate = discount.DiscountRate,
                    CategoryName = category?.CategoryName,
                    ProductName = product?.ProductName,
                    CategoryImageURL = category?.CategoryImageURL,
                    ProductImageURL = product?.ProductImageURL
                };

                result.Add(discountDto);
            }

            return result;
        }

        public async Task<GetByIdDiscountDto> GetByIdDiscountAsync(string discountId)
        {
            var values = await _discountCollection.Find(x => x.DiscountId == discountId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDiscountDto>(values);
        }

        public async Task<List<ResultDiscountWithProductOrCategoryDto>> GetRandom2DiscountWithCategoryDtoAsync()
        {
            var categoryDiscounts = await _discountCollection
                .Find(x => string.IsNullOrEmpty(x.ProductId) && !string.IsNullOrEmpty(x.CategoryId))
                .ToListAsync();

            var randomDiscounts = categoryDiscounts
                .OrderBy(x => Guid.NewGuid())
                .Take(2)
                .ToList();

            var result = new List<ResultDiscountWithProductOrCategoryDto>();

            foreach (var discount in randomDiscounts)
            {
                var category = await _categoryCollection
                    .Find(x => x.CategoryId == discount.CategoryId)
                    .FirstOrDefaultAsync();

                var discountDto = new ResultDiscountWithProductOrCategoryDto
                {
                    DiscountId = discount.DiscountId,
                    DiscountRate = discount.DiscountRate,
                    CategoryName = category?.CategoryName,
                    CategoryImageURL = category?.CategoryImageURL,
                    ProductName = null,
                    ProductImageURL = null
                };

                result.Add(discountDto);
            }

            return result;
        }

        public async Task<List<ResultDiscountWithProductOrCategoryDto>> GetRandom2DiscountWithProductDtoAsync()
        {
            var productDiscounts = await _discountCollection
                .Find(x => string.IsNullOrEmpty(x.CategoryId) && !string.IsNullOrEmpty(x.ProductId))
                .ToListAsync();

            var randomDiscounts = productDiscounts
                .OrderBy(x => Guid.NewGuid())
                .Take(2)
                .ToList();

            var result = new List<ResultDiscountWithProductOrCategoryDto>();

            foreach (var discount in randomDiscounts)
            {
                var product = await _productCollection
                    .Find(x => x.ProductId == discount.ProductId)
                    .FirstOrDefaultAsync();

                var discountDto = new ResultDiscountWithProductOrCategoryDto
                {
                    DiscountId = discount.DiscountId,
                    DiscountRate = discount.DiscountRate,
                    ProductName = product?.ProductName,
                    ProductImageURL = product?.ProductImageURL,
                    CategoryName = null,
                    CategoryImageURL = null
                };

                result.Add(discountDto);
            }

            return result;
        }

        public async Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto)
        {
            var values = _mapper.Map<Discount>(updateDiscountDto);
            await _discountCollection.FindOneAndReplaceAsync(x => x.DiscountId == updateDiscountDto.DiscountId, values);
        }
    }
}
