using PromotionEngine.Utils.UnitPriceForSKUIDs.Interface;
namespace PromotionEngine.Utils.UnitPriceForSKUIDs.Impl
{
    public class B : IUnitPrice
    {
        public double UnitPrice { get; set; }
        public string UnitName { get; set; }
        public B()
        {
            this.UnitPrice = 30;
            this.UnitName = "B";
        }
        public B(double UnitPrice)
        {
            this.UnitPrice = UnitPrice;
        }

        public B(double UnitPrice, string UnitName)
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
