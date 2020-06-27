using System;
using System.Collections.Generic;


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
