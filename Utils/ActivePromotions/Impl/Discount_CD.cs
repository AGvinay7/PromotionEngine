using PromotionEngines.Utils.ActivePromotions.Interface;

namespace PromotionEngine.Utils.ActivePromotions.Impl
{
    public class Discount_CD : IActivePromotions
    {
        public int NoOfItems { get; set; }
        public double DiscountOffered { get; set; }
        public string ItemName { get; set; }
        public Discount_CD()
        {
            this.DiscountOffered = 30;
            this.ItemName = "CD";
            this.NoOfItems = 1;
        }
    }
}
