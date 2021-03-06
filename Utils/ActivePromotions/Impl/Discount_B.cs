﻿using PromotionEngines.Utils.ActivePromotions.Interface;

namespace PromotionEngines.Utils.ActivePromotions.Impl
{
    public class Discount_B : IActivePromotions
    {
        public int NoOfItems { get; set; }
        public double DiscountOffered { get; set; }
        public string ItemName { get; set; }
        public Discount_B()
        {
            this.DiscountOffered = 45;
            this.ItemName = "B";
            this.NoOfItems = 2;
        }
    }
}
