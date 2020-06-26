using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngines.Utils.ActivePromotions.Interface
{
    public interface IActivePromotions
    {
        int NoOfItems { get; set; }
        double DiscountOffered { get; set; }
    }
}
