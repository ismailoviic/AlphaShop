using AlphaShop.Constants;
using AlphaShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaShop.Shop
{
    public class ShopReader : AbstractPostgreSqlRepository, IShopReader
    {
        public ShopReader(PostgreSqlConfiguration postgreSqlConfiguration) : base(postgreSqlConfiguration)
        {
        }
        public ItemInfo GetItemInfo(Guid itemId)
        {
            var name = QueryFirstAsync <string>( $"SELECT items_name as name FROM items WHERE item_id='{itemId}'");
            var price= QueryFirstAsync<decimal>($"SELECT price FROM items WHERE item_id='{itemId}'");
            return new ItemInfo{ name=name.Result,price=price.Result };
        }
        public Task<RayInfo> GetRayInfo(Rays ray)
        {
            throw new NotImplementedException();
        }
        public Task<decimal> GetTheString(Guid itemId)
            => QueryFirstAsync<decimal>($"SELECT price as Price FROM items WHERE item_id='{itemId}'");
        public Task<Promo> GetPromo(Guid itemId) {
            return QueryFirstAsync<Promo>($"SELECT * FROM promotion WHERE item_id='{itemId}'");
        }
        public Task<bool> StockOutForItem(Guid itemId)
        {
            throw new NotImplementedException();
        }
        public Task<IsmaTest> GetIsmaInfo(Guid itemId) {
            return QueryFirstAsync<IsmaTest>($"SELECT * FROM ismatable WHERE id='{itemId}'");
        }
    }
}
//ca6e29ef-0578-40fa-8086-2eb40f8df5d2