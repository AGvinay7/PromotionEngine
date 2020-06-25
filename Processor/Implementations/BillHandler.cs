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
        private object _activePromotions;
        AddItemResponseModel Bill = new AddItemResponseModel();



        public BillHandler(IActivePromotions activePromotions)
        {
            _activePromotions = activePromotions;
        }



        public AddItemResponseModel GenerateBill(AddItemRequestModel item)
        {

            double unitPrice = GetUnitPriceOfItem(item);
            Bill.Total = CheckPromoDiscount(unitPrice, item);
            Bill.ItemsPurchased.Add(item.ItemType);
            return Bill;
        }




        private static double GetUnitPriceOfItem(AddItemRequestModel item)
        {
            var UnitsFactory = new UnitPriceFactory();
            IUnitPrice unitPriceOfItem = UnitsFactory.GetUnitPrice(item.ItemType);
            var unitPrice = unitPriceOfItem.GetUnitPrice();
            return unitPrice;
        }




        private double CheckPromoDiscount(double unitPrice, AddItemRequestModel item) // 50 , A
        {
            var promotionForItem = new DiscountsFactory().GetPromotions(item.ItemType);

            Bill.IsPromoApplied = item.ItemQuantity >= promotionForItem.NoOfItems;            
            var discountedAmt = (item.ItemQuantity / promotionForItem.NoOfItems) * promotionForItem.DiscountOffered;
            var additionalAmount = (item.ItemQuantity % promotionForItem.NoOfItems) * unitPrice;
            Bill.Date = DateTime.Now;
            return discountedAmt + additionalAmount;
        }
    }
}
