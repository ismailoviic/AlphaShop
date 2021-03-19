using AlphaShop.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaShop.Shop
{
    public class Item
    {
        public int Id;
        public Rays Ray;
        public ItemName ItemName;
        public Size Size;
        public decimal Price;
        public Promo Promo;
        public int Quantity;
    }
}
