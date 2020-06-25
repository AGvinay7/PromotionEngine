using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Utils.ActivePromotions.Interface
{
    public interface IActivePromotions
    {
        int NoOfItems { get; set; }
        double DiscountOffered { get; set; }
    }
}
