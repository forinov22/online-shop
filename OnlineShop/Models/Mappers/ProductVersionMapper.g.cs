using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs;

namespace OnlineShop.Models.Mappers;

public static partial class ProductVersionMapper
{
    private static TypeAdapterConfig TypeAdapterConfig;
        
    public static ProductVersionDto AdaptToDto(this ProductVersion entity)
    {
        return entity == null ? null : new ProductVersionDto()
        {
            Id = entity.Id,
            Quantity = entity.Quantity,
            Sku = entity.Sku,
            ProductId = entity.ProductId,
            SizeId = entity.SizeId,
            ColorId = entity.ColorId,
            Color = entity.Color == null ? null : new ColorDto()
            {
                Id = entity.Color.Id,
                Name = entity.Color.Name
            },
            Product = entity.Product == null ? null : new ProductDto()
            {
                Id = entity.Product.Id,
                Name = entity.Product.Name,
                Price = entity.Product.Price,
                BrandId = entity.Product.BrandId,
                CategoryId = entity.Product.CategoryId,
                AverageRating = entity.Product.AverageRating,
                Brand = entity.Product.Brand == null ? null : new BrandDto()
                {
                    Id = entity.Product.Brand.Id,
                    Name = entity.Product.Brand.Name
                },
                Category = entity.Product.Category == null ? null : new CategoryDto()
                {
                    Id = entity.Product.Category.Id,
                    Name = entity.Product.Category.Name,
                    ParentCategoryId = entity.Product.Category.ParentCategoryId,
                    ParentCategory = TypeAdapterConfig.GetMapFunction<Category, CategoryDto>().Invoke(entity.Product.Category.ParentCategory)
                }
            },
            Size = entity.Size == null ? null : new SizeDto()
            {
                Id = entity.Size.Id,
                Name = entity.Size.Name
            }
        };
    }
    
    public static ProductVersion AdaptToProductVersion(this ProductVersionAdd dto)
    {
        return dto == null ? null : new ProductVersion()
        {
            Quantity = dto.Quantity,
            Sku = dto.Sku,
            ProductId = dto.ProductId,
            SizeId = dto.SizeId,
            ColorId = dto.ColorId
        };
    }
}