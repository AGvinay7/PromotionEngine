using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngines.Models
{
    public class AddItemResponseModel 
    {
        public double Total { get; set; }       
        public bool IsPromoApplied { get; set; }
        public IList<string> ItemsPurchased = new List<string>();
        public DateTime Date { get; set; }
        
    }
}
