using PromotionEngine.Utils.ActivePromotions.Impl;
using PromotionEngines.Utils.ActivePromotions.Interface;

namespace PromotionEngines.Utils.ActivePromotions.Impl
{
    public class DiscountsFactory
    {
        public IActivePromotions GetPromotions(string type)
        {
            switch (type)
            {
                case "A": return new Discount_A();
                case "B": return new Discount_B(); 
                case "C": return new Discount_CD();
                case "D": return new Discount_CD(); // promotion for both C and D are same 

                default: break;
            }
            return null;
        }
    }
}
