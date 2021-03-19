using AlphaShop.Constants;
using AlphaShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaShop.Shop
{
    public class ShopWriter : AbstractPostgreSqlRepository, IShopWriter
    {
        public ShopWriter(PostgreSqlConfiguration postgreSqlConfiguration) : base(postgreSqlConfiguration)
        {
        }
        public void AddItems(Guid itemId, Size size, int quantity)
        {
            throw new NotImplementedException();
        }

        public void PromotingItem(Guid itemId, string promoName, int percentage)
        {
            throw new NotImplementedException();
        }

        public void SellItem(Guid itemId, Size size, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
