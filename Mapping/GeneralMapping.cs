using AutoMapper;
using Project8FoodMartProjectWithMongoDB.Dtos.CategoryDtos;
using Project8FoodMartProjectWithMongoDB.Dtos.DiscountDtos;
using Project8FoodMartProjectWithMongoDB.Dtos.FeatureDtos;
using Project8FoodMartProjectWithMongoDB.Dtos.ProductDtos;
using Project8FoodMartProjectWithMongoDB.Dtos.SaleDtos;
using Project8FoodMartProjectWithMongoDB.Entities;

namespace Project8FoodMartProjectWithMongoDB.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountDto>().ReverseMap();

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<Sale, CreateSaleDto>().ReverseMap();
            CreateMap<Sale, UpdateSaleDto>().ReverseMap();
            CreateMap<Sale, ResultSaleDto>().ReverseMap();
            CreateMap<Sale, GetByIdSaleDto>().ReverseMap();

            CreateMap<Product, ResultProductWithCategoryDto>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName))
                .ForMember(a => a.CategoryImageURL, b => b.MapFrom(c => c.Category.CategoryImageURL));

            CreateMap<Sale, ResultSaleWithProductDto>()
                .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product.ProductName))
                .ForMember(x => x.UnitType, y => y.MapFrom(z => z.Product.UnitType))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Product.Price))
                .ForMember(x => x.ProductImageURL, y => y.MapFrom(z => z.Product.ProductImageURL));
        }
    }
}
