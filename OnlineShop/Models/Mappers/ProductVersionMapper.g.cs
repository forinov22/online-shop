using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class ProductVersionMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static ProductVersionDto AdaptToDto(this ProductVersion p1)
        {
            return p1 == null ? null : new ProductVersionDto()
            {
                Id = p1.Id,
                Quantity = p1.Quantity,
                Sku = p1.Sku,
                ProductId = p1.ProductId,
                SizeId = p1.SizeId,
                ColorId = p1.ColorId,
                Color = p1.Color == null ? null : new ColorDto()
                {
                    Id = p1.Color.Id,
                    Name = p1.Color.Name
                },
                Product = p1.Product == null ? null : new ProductDto()
                {
                    Id = p1.Product.Id,
                    Name = p1.Product.Name,
                    Price = p1.Product.Price,
                    BrandId = p1.Product.BrandId,
                    CategoryId = p1.Product.CategoryId,
                    AverageRating = p1.Product.AverageRating,
                    Brand = p1.Product.Brand == null ? null : new BrandDto()
                    {
                        Id = p1.Product.Brand.Id,
                        Name = p1.Product.Brand.Name
                    },
                    Category = p1.Product.Category == null ? null : new CategoryDto()
                    {
                        Id = p1.Product.Category.Id,
                        Name = p1.Product.Category.Name,
                        ParentCategoryId = p1.Product.Category.ParentCategoryId,
                        ParentCategory = TypeAdapterConfig1.GetMapFunction<Category, CategoryDto>().Invoke(p1.Product.Category.ParentCategory)
                    }
                },
                Size = p1.Size == null ? null : new SizeDto()
                {
                    Id = p1.Size.Id,
                    Name = p1.Size.Name
                }
            };
        }
        public static ProductVersionDto AdaptTo(this ProductVersion p2, ProductVersionDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            ProductVersionDto result = p3 ?? new ProductVersionDto();
            
            result.Id = p2.Id;
            result.Quantity = p2.Quantity;
            result.Sku = p2.Sku;
            result.ProductId = p2.ProductId;
            result.SizeId = p2.SizeId;
            result.ColorId = p2.ColorId;
            result.Color = p2.Color.AdaptToDto();
            result.Product = p2.Product.AdaptToDto();
            result.Size = p2.Size.AdaptToDto();
            return result;
            
        }
        public static ProductVersion AdaptToProductVersion(this ProductVersionAdd p14)
        {
            return p14 == null ? null : new ProductVersion()
            {
                Quantity = p14.Quantity,
                Sku = p14.Sku,
                ProductId = p14.ProductId,
                SizeId = p14.SizeId,
                ColorId = p14.ColorId
            };
        }
        public static ProductVersion AdaptTo(this ProductVersionAdd p15, ProductVersion p16)
        {
            if (p15 == null)
            {
                return null;
            }
            ProductVersion result = p16 ?? new ProductVersion();
            
            result.Quantity = p15.Quantity;
            result.Sku = p15.Sku;
            result.ProductId = p15.ProductId;
            result.SizeId = p15.SizeId;
            result.ColorId = p15.ColorId;
            return result;
            
        }
        public static ProductVersion AdaptToProductVersion(this ProductVersionUpdate p17)
        {
            return p17 == null ? null : new ProductVersion()
            {
                Quantity = p17.Quantity,
                Sku = p17.Sku,
                ProductId = p17.ProductId,
                SizeId = p17.SizeId,
                ColorId = p17.ColorId
            };
        }
        public static ProductVersion AdaptTo(this ProductVersionUpdate p18, ProductVersion p19)
        {
            if (p18 == null)
            {
                return null;
            }
            ProductVersion result = p19 ?? new ProductVersion();
            
            result.Quantity = p18.Quantity;
            result.Sku = p18.Sku;
            result.ProductId = p18.ProductId;
            result.SizeId = p18.SizeId;
            result.ColorId = p18.ColorId;
            return result;
            
        }
    }
}