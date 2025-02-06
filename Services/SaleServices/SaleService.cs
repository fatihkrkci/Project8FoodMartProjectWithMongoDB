using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Project8FoodMartProjectWithMongoDB.Dtos.ProductDtos;
using Project8FoodMartProjectWithMongoDB.Dtos.SaleDtos;
using Project8FoodMartProjectWithMongoDB.Entities;
using Project8FoodMartProjectWithMongoDB.Settings;

namespace Project8FoodMartProjectWithMongoDB.Services.SaleServices
{
    public class SaleService : ISaleService
    {
        private readonly IMongoCollection<Sale> _saleCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public SaleService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _saleCollection = database.GetCollection<Sale>(_databaseSettings.SaleCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSaleAsync(CreateSaleDto createSaleDto)
        {
            var value = _mapper.Map<Sale>(createSaleDto);
            await _saleCollection.InsertOneAsync(value);
        }

        public async Task DeleteSaleAsync(string saleId)
        {
            await _saleCollection.DeleteOneAsync(x => x.SaleId == saleId);
        }

        public async Task<List<ResultSaleDto>> GetAllSaleAsync()
        {
            var values = await _saleCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSaleDto>>(values);
        }

        public async Task<List<ResultSaleWithProductDto>> GetAllSalesWithProductAsync()
        {
            var values = await _saleCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Product = await _productCollection.Find(x => x.ProductId == item.ProductId).FirstAsync();
            }
            return _mapper.Map<List<ResultSaleWithProductDto>>(values);
        }

        public async Task<GetByIdSaleDto> GetByIdSaleAsync(string saleId)
        {
            var values = await _saleCollection.Find(x => x.SaleId == saleId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSaleDto>(values);
        }

        public async Task<List<ResultSaleWithProductDto>> GetTop6SalesWithProductAsync()
        {
            var topSalesByProduct = await _saleCollection
                .Aggregate()
                .Group(
                    x => x.ProductId,
                    g => new
                    {
                        ProductId = g.Key,
                        MaxSale = g.OrderByDescending(x => x.NumberOfProducts).FirstOrDefault()
                    }
                )
                .SortByDescending(x => x.MaxSale.NumberOfProducts)
                .Limit(6)
                .ToListAsync();

            var topProductIds = topSalesByProduct.Select(x => x.ProductId).ToList();

            var topProducts = await _productCollection
                .Find(x => topProductIds.Contains(x.ProductId))
                .ToListAsync();

            var result = topSalesByProduct
                .Join(topProducts,
                      sale => sale.ProductId,
                      product => product.ProductId,
                      (sale, product) => new ResultSaleWithProductDto
                      {
                          SaleId = sale.MaxSale.SaleId,
                          NumberOfProducts = sale.MaxSale.NumberOfProducts,
                          TotalPrice = sale.MaxSale.TotalPrice,
                          ProductName = product.ProductName,
                          UnitType = product.UnitType,
                          Price = product.Price.ToString(),
                          ProductImageURL = product.ProductImageURL
                      })
                .ToList();

            return result;
        }

        public async Task UpdateSaleAsync(UpdateSaleDto updateSaleDto)
        {
            var values = _mapper.Map<Sale>(updateSaleDto);
            await _saleCollection.FindOneAndReplaceAsync(x => x.SaleId == updateSaleDto.SaleId, values);
        }
    }
}
