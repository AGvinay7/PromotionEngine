using PromotionEngine.Utils.UnitPriceForSKUIDs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Utils.UnitPriceForSKUIDs.Impl
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
