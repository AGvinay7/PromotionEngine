using PromotionEngines.Utils.ActivePromotions.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngines.Utils.ActivePromotions.Impl
{
    public class Discount_A : IActivePromotions
    {
        public int NoOfItems { get; set; }
        public double DiscountOffered { get; set; }
        public string ItemName { get; set; }
        public Discount_A()
        {
            this.DiscountOffered = 130;
            this.ItemName = "A";
            this.NoOfItems = 3;
        }
    }
}
