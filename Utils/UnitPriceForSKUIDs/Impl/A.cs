using PromotionEngine.Utils.UnitPriceForSKUIDs.Interface;
namespace PromotionEngine.Utils.UnitPriceForSKUIDs.Impl
{
    public class A : IUnitPrice
    {
        public double UnitPrice { get; set; }
        public string UnitName { get; set; }
        public A()
        {
            this.UnitPrice = 50;
            this.UnitName = "A";
        }
        public A(double UnitPrice)
        {
            this.UnitPrice = UnitPrice;
        }

        public A(double UnitPrice, string UnitName)
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
