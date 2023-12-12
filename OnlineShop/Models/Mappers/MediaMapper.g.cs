using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop.Domains
{
    public static partial class MediaMapper
    {
        private static TypeAdapterConfig TypeAdapterConfig1;
        
        public static MediaDto AdaptToDto(this Media p1)
        {
            return p1 == null ? null : new MediaDto()
            {
                Id = p1.Id,
                Bytes = p1.Bytes,
                FileType = p1.FileType,
                FileName = p1.FileName,
                ProductId = p1.ProductId,
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
                }
            };
        }
        public static MediaDto AdaptTo(this Media p2, MediaDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MediaDto result = p3 ?? new MediaDto();
            
            result.Id = p2.Id;
            result.Bytes = p2.Bytes;
            result.FileType = p2.FileType;
            result.FileName = p2.FileName;
            result.ProductId = p2.ProductId;
            result.Product = p2.Product.AdaptToDto();
            return result;
            
        }
        public static Media AdaptToMedia(this MediaAdd p10)
        {
            return p10 == null ? null : new Media()
            {
                Bytes = p10.Bytes,
                FileType = p10.FileType,
                FileName = p10.FileName,
                ProductId = p10.ProductId
            };
        }
        public static Media AdaptTo(this MediaAdd p11, Media p12)
        {
            if (p11 == null)
            {
                return null;
            }
            Media result = p12 ?? new Media();
            
            result.Bytes = p11.Bytes;
            result.FileType = p11.FileType;
            result.FileName = p11.FileName;
            result.ProductId = p11.ProductId;
            return result;
            
        }
        public static Media AdaptToMedia(this MediaUpdate p13)
        {
            return p13 == null ? null : new Media()
            {
                Bytes = p13.Bytes,
                FileType = p13.FileType,
                FileName = p13.FileName,
                ProductId = p13.ProductId
            };
        }
        public static Media AdaptTo(this MediaUpdate p14, Media p15)
        {
            if (p14 == null)
            {
                return null;
            }
            Media result = p15 ?? new Media();
            
            result.Bytes = p14.Bytes;
            result.FileType = p14.FileType;
            result.FileName = p14.FileName;
            result.ProductId = p14.ProductId;
            return result;
            
        }
    }
}