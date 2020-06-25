using PromotionEngine.Models;
using PromotionEngine.Processor.Interface;
using PromotionEngine.Utils.ActivePromotions.Impl;
using PromotionEngine.Utils.ActivePromotions.Interface;
using PromotionEngine.Utils.UnitPriceForSKUIDs.Impl;
using PromotionEngine.Utils.UnitPriceForSKUIDs.Interface;
using System;

namespace PromotionEngine.Processor.Implementations
{
    public class BillHandler : IBillHandler
    {

        public AddItemResponseModel Bill = new AddItemResponseModel();
        private bool isPromoApplied;
        private bool Flag = false;

        public AddItemResponseModel GenerateBill(AddItemRequestModel item)
        {

            double unitPrice = GetUnitPriceOfItem(item);
            Bill.Total = CheckPromoDiscount(unitPrice, item);           
            Bill.ItemsPurchased.Add(item.ItemType);
            Bill.IsPromoApplied = isPromoApplied;
            return Bill;
        }

        private static double GetUnitPriceOfItem(AddItemRequestModel item)
        {
            var UnitsFactory = new UnitPriceFactory();
            IUnitPrice unitPriceOfItem = UnitsFactory.GetUnitPrice(item.ItemType);
            var unitPrice = unitPriceOfItem.GetUnitPrice();
            return unitPrice;
        }

        private double CheckPromoDiscount(double unitPrice, AddItemRequestModel item)
        {
            var promotionForItem = new DiscountsFactory().GetPromotions(item.ItemType);
            var OnDiscountPrice = (item.ItemQuantity / promotionForItem.NoOfItems) * promotionForItem.DiscountOffered;
            if(!Flag)
            {
                isPromoApplied = OnDiscountPrice > 0;
                Flag = true;
            }
            var OffDiscountPrice = (item.ItemQuantity % promotionForItem.NoOfItems) * unitPrice;
            return OnDiscountPrice + OffDiscountPrice;
        }
    }
}
