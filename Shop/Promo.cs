using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaShop.Shop
{
    public class Promo
    {
        public Guid Id;
        public Guid ItemId;
        public bool InPromo;
        public string PromoName;
        public int Percentage;
    }
}
