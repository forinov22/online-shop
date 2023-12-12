using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class ProductMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static ProductDto AdaptToDto(this Product p1)
        {
            return p1 == null ? null : new ProductDto()
            {
                Id = p1.Id,
                Name = p1.Name,
                Price = p1.Price,
                BrandId = p1.BrandId,
                CategoryId = p1.CategoryId,
                AverageRating = p1.AverageRating,
                Brand = p1.Brand == null ? null : new BrandDto()
                {
                    Id = p1.Brand.Id,
                    Name = p1.Brand.Name
                },
                Category = p1.Category == null ? null : new CategoryDto()
                {
                    Id = p1.Category.Id,
                    Name = p1.Category.Name,
                    ParentCategoryId = p1.Category.ParentCategoryId,
                    ParentCategory = TypeAdapterConfig1.GetMapFunction<Category, CategoryDto>().Invoke(p1.Category.ParentCategory)
                }
            };
        }
        public static ProductDto AdaptTo(this Product p2, ProductDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            ProductDto result = p3 ?? new ProductDto();
            
            result.Id = p2.Id;
            result.Name = p2.Name;
            result.Price = p2.Price;
            result.BrandId = p2.BrandId;
            result.CategoryId = p2.CategoryId;
            result.AverageRating = p2.AverageRating;
            result.Brand = p2.Brand.AdaptToDto();
            result.Category = p2.Category.AdaptToDto();
            return result;
            
        }
        public static Product AdaptToProduct(this ProductAdd p8)
        {
            return p8 == null ? null : new Product()
            {
                Name = p8.Name,
                Price = p8.Price,
                BrandId = p8.BrandId,
                CategoryId = p8.CategoryId,
                AverageRating = p8.AverageRating
            };
        }
        public static Product AdaptTo(this ProductAdd p9, Product p10)
        {
            if (p9 == null)
            {
                return null;
            }
            Product result = p10 ?? new Product();
            
            result.Name = p9.Name;
            result.Price = p9.Price;
            result.BrandId = p9.BrandId;
            result.CategoryId = p9.CategoryId;
            result.AverageRating = p9.AverageRating;
            return result;
            
        }
        public static Product AdaptToProduct(this ProductUpdate p11)
        {
            return p11 == null ? null : new Product()
            {
                Name = p11.Name,
                Price = p11.Price,
                BrandId = p11.BrandId,
                CategoryId = p11.CategoryId,
                AverageRating = p11.AverageRating
            };
        }
        public static Product AdaptTo(this ProductUpdate p12, Product p13)
        {
            if (p12 == null)
            {
                return null;
            }
            Product result = p13 ?? new Product();
            
            result.Name = p12.Name;
            result.Price = p12.Price;
            result.BrandId = p12.BrandId;
            result.CategoryId = p12.CategoryId;
            result.AverageRating = p12.AverageRating;
            return result;
            
        }
    }
}