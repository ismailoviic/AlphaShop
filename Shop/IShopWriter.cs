using AlphaShop.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaShop.Shop
{
    public interface IShopWriter
    {
        public void SellItem(Guid itemId,Size size,int quantity);
        public void AddItems(Guid itemId, Size size, int quantity);
        public void PromotingItem(Guid itemId,string promoName ,int percentage);
    }
}
