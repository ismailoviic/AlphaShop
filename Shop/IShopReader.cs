using AlphaShop.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaShop.Shop
{
    public interface IShopReader
    {
        public Task<bool> StockOutForItem(Guid itemId);
        public Task<RayInfo> GetRayInfo(Rays ray);
        public ItemInfo GetItemInfo(Guid itemId);
        public Task<decimal> GetTheString(Guid itemId);
        public Task<Promo> GetPromo(Guid itemId);
        public Task<IsmaTest> GetIsmaInfo(Guid itemId);
    }
}
