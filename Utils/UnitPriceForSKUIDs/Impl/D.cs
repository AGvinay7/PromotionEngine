using PromotionEngines.Utils.UnitPriceForSKUIDs.Interface;
namespace PromotionEngines.Utils.UnitPriceForSKUIDs.Impl
{
    public class D : IUnitPrice
    {
        public double UnitPrice { get; set; }
        public string UnitName { get; set; }
        public D()
        {
            this.UnitPrice = 15;
            this.UnitName = "D";
        }
        public D(double UnitPrice)
        {
            this.UnitPrice = UnitPrice;
        }

        public D(double UnitPrice, string UnitName)
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
