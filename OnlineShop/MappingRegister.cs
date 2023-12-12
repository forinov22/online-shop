using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Mapster;
using OnlineShop.Domains;
using OnlineShop.Models.DTOs.OnlineShop.Domains;

namespace OnlineShop;

public class MappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Category, CategoryDto>()
            .MaxDepth(3);
    }
}

public class MappingRegister : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto")
            .ApplyDefaultRule()
            .MaxDepth(1);

        config.AdaptFrom("[name]Add")
            .ApplyDefaultRule()
            .IgnoreAttributes(typeof(KeyAttribute))
            .IgnoreNoModifyProperties();

        config.AdaptFrom("[name]Update")
            .ApplyDefaultRule()
            .IgnoreAttributes(typeof(KeyAttribute))
            .IgnoreNoModifyProperties();

        config.GenerateMapper("[name]Mapper")
            .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "OnlineShop.Domains")
            .ExcludeTypes(type => type.IsEnum);
    }
}

static class RegisterExtensions
{
    public static AdaptAttributeBuilder ApplyDefaultRule(this AdaptAttributeBuilder builder)
    {
        return builder
            .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "OnlineShop.Domains")
            .ExcludeTypes(type => type.IsEnum)
            .AlterType(type => type.IsEnum || Nullable.GetUnderlyingType(type)?.IsEnum == true, typeof(string))
            .ShallowCopyForSameType(true)
            .ForType<User>(cfg =>
            {
                cfg.Ignore(it => it.CartItems);
                cfg.Ignore(it => it.Orders);
                cfg.Ignore(it => it.Reviews);
            })
            .ForType<Size>(cfg =>
            {
                cfg.Ignore(it => it.ProductVersions);
            })
            .ForType<Section>(cfg =>
            {
                cfg.Ignore(it => it.Categories);
            })
            .ForType<ProductVersion>(cfg =>
            {
                cfg.Ignore(it => it.CartItems);
                cfg.Ignore(it => it.OrderItems);
            })
            .ForType<Product>(cfg =>
            {
                cfg.Ignore(it => it.ProductVersions);
                cfg.Ignore(it => it.Media);
                cfg.Ignore(it => it.Reviews);
            })
            .ForType<Order>(cfg =>
            {
                cfg.Ignore(it => it.OrderItems);
                cfg.Ignore(it => it.OrderTransactions);
            })
            .ForType<Color>(cfg =>
            {
                cfg.Ignore(it => it.ProductVersions);
            })
            .ForType<Category>(cfg =>
            {
                cfg.Ignore(it => it.Products);
                cfg.Ignore(it => it.Sections);
            })
            .ForType<Brand>(cfg =>
            {
                cfg.Ignore(it => it.Products);
            })
            .ForType<Address>(cfg =>
            {
                cfg.Ignore(it => it.Orders);
            });
    }

    public static AdaptAttributeBuilder IgnoreNoModifyProperties(this AdaptAttributeBuilder builder)
    {
        return builder
            .ForType<User>(cfg =>
            {
                cfg.Ignore(it => it.Address);
                cfg.Ignore(it => it.CartItems);
                cfg.Ignore(it => it.Orders);
                cfg.Ignore(it => it.Reviews);
            })
            .ForType<Size>(cfg =>
            {
                cfg.Ignore(it => it.ProductVersions);
            })
            .ForType<Section>(cfg =>
            {
                cfg.Ignore(it => it.Categories);
            })
            .ForType<Review>(cfg =>
            {
                cfg.Ignore(it => it.Product);
                cfg.Ignore(it => it.User);
            })
            .ForType<ProductVersion>(cfg =>
            {
                cfg.Ignore(it => it.CartItems);
                cfg.Ignore(it => it.OrderItems);
                cfg.Ignore(it => it.Color);
                cfg.Ignore(it => it.Product);
                cfg.Ignore(it => it.Size);
            })
            .ForType<Product>(cfg =>
            {
                cfg.Ignore(it => it.ProductVersions);
                cfg.Ignore(it => it.Media);
                cfg.Ignore(it => it.Reviews);
                cfg.Ignore(it => it.Brand);
                cfg.Ignore(it => it.Category);
            })
            .ForType<OrderTransaction>(cfg =>
            {
                cfg.Ignore(it => it.Order);
            })
            .ForType<OrderItem>(cfg =>
            {
                cfg.Ignore(it => it.Order);
                cfg.Ignore(it => it.ProductVersion);
            })
            .ForType<Order>(cfg =>
            {
                cfg.Ignore(it => it.OrderItems);
                cfg.Ignore(it => it.OrderTransactions);
                cfg.Ignore(it => it.Address);
                cfg.Ignore(it => it.User);
            })
            .ForType<Media>(cfg =>
            {
                cfg.Ignore(it => it.Product);
            })
            .ForType<Color>(cfg =>
            {
                cfg.Ignore(it => it.ProductVersions);
            })
            .ForType<Category>(cfg =>
            {
                cfg.Ignore(it => it.Products);
                cfg.Ignore(it => it.Sections);
                cfg.Ignore(it => it.ParentCategory);
            })
            .ForType<CartItem>(cfg =>
            {
                cfg.Ignore(it => it.ProductVersion);
                cfg.Ignore(it => it.User);
            })
            .ForType<Brand>(cfg =>
            {
                cfg.Ignore(it => it.Products);
            })
            .ForType<Address>(cfg =>
            {
                cfg.Ignore(it => it.Orders);
                cfg.Ignore(it => it.User);
            });
    }
}