using PromotionEngines.Utils.UnitPriceForSKUIDs.Interface;


namespace PromotionEngines.Utils.UnitPriceForSKUIDs.Impl
{
    public class UnitPriceFactory
    {
        public IUnitPrice GetUnitPrice(string type)
        {
            if (!string.IsNullOrEmpty(type))
            {

                switch (type)
                {
                    case "A": return new A();
                    case "B": return new B();
                    case "C": return new C();
                    case "D": return new D();
                    default: break;
                }

            }
            return null;
        }

    }
}
