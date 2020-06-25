using PromotionEngine.Models;
using PromotionEngine.Utils.ActivePromotions.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Utils.ActivePromotions.Impl
{
    public class DiscountsFactory
    {
        public IActivePromotions GetPromotions(string type)
        {
            switch (type)
            {
                case "A": return new Discount_A();
                case "B": return new Discount_B();            

                default: break;
            }
            return null;
        }
    }
}
