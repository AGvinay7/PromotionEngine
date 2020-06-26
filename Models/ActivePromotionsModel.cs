using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class ActivePromotionsModel
    {
        public string ItemName { get; set; }
        public int NoOfItems { get; set; }
        public double DiscountRunning { get; set; }

    }
}
