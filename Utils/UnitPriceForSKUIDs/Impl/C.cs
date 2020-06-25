using PromotionEngine.Utils.UnitPriceForSKUIDs.Interface;
namespace PromotionEngine.Utils.UnitPriceForSKUIDs.Impl
{
    public class C : IUnitPrice
    {
        public double UnitPrice { get; set; }
        public string UnitName { get; set; }
        public C()
        {
            this.UnitPrice = 20;
            this.UnitName = "C";
        }
        public C(double UnitPrice)
        {
            this.UnitPrice = UnitPrice;
        }

        public C(double UnitPrice, string UnitName)
        {
            this.UnitPrice = UnitPrice;
            this.UnitName = UnitName;
        }

        public double GetUnitPrice()
        {
            return this.UnitPrice;
        }
    }
}
