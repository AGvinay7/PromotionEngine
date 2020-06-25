using PromotionEngine.Models;
using PromotionEngine.Processor.Interface;
using PromotionEngine.Utils.UnitPriceForSKUIDs.Impl;
using PromotionEngine.Utils.UnitPriceForSKUIDs.Interface;
using System;

namespace PromotionEngine.Processor.Implementations
{
    public class BillHandler : IBillHandler
    {
        public double GenerateBill(AddItemRequestModel item)
        {
            var UnitsFactory = new UnitPriceFactory();
            IUnitPrice unitPriceOfItem = UnitsFactory.GetUnitPrice(item.ItemType);
            var unitPrice = unitPriceOfItem.GetUnitPrice();
            var totalAmt = CheckPromoDiscount(unitPrice, item);
            return 0.00;
        }

        private object CheckPromoDiscount(double unitPrice, AddItemRequestModel item)
        {
            
        }
    }
}
