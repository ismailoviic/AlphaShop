
using AlphaShop.Shop;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AlphaShop.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UsePostgreSql(this IServiceCollection services,
            IConfigurationSection configuration)
            => services
                .Configure<PostgreSqlConfiguration>(configuration)
                .AddTransient(x => x.GetService<IOptions<PostgreSqlConfiguration>>().Value)
                .AddTransient<IShopReader, ShopReader>()
                .AddTransient<IShopWriter, ShopWriter>();
    }
}