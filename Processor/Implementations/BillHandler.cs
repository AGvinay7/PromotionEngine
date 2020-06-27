using PromotionEngines.Models;
using PromotionEngines.Processor.Interface;
using PromotionEngines.Utils.ActivePromotions.Impl;
using PromotionEngines.Utils.UnitPriceForSKUIDs.Impl;
using PromotionEngines.Utils.UnitPriceForSKUIDs.Interface;
using System.Linq;
using System.Collections.Generic;

namespace PromotionEngines.Processor.Implementations
{
    public class BillHandler : IBillHandler
    {

        public AddItemResponseModel Bill = new AddItemResponseModel();
        private bool isPromoApplied;
        private bool Flag = false;

        public AddItemResponseModel GenerateBill(AddItemRequestModel item)
        {

            double unitPrice = GetUnitPriceOfItem(item);
            if (item.ItemType.Equals("C") || item.ItemType.Equals("D"))
            {
                Bill.Total = unitPrice * item.ItemQuantity;
            }
            else
            {
                Bill.Total = CheckPromoDiscount(unitPrice, item);
            }

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
            if (!Flag)
            {
                isPromoApplied = OnDiscountPrice > 0;
                Flag = true;
            }
            var OffDiscountPrice = (item.ItemQuantity % promotionForItem.NoOfItems) * unitPrice;
            return OnDiscountPrice + OffDiscountPrice;
        }

        public double GenerateBillForCAndD(IList<AddItemRequestModel> items)
        {
            var promotionForItem = new DiscountsFactory().GetPromotions(items.FirstOrDefault().ItemType);
            var minimumCommonQtyinBoth = items.Select(x => x.ItemQuantity).Min();
            var OnDiscountPrice = minimumCommonQtyinBoth * promotionForItem.DiscountOffered;
            if (!Flag)
            {
                isPromoApplied = OnDiscountPrice > 0;
                Flag = true;
            }

            var itemWithMoreQty = items.Where(x => x.ItemQuantity > minimumCommonQtyinBoth);

            var unitPrice = GetUnitPriceOfItem(itemWithMoreQty.FirstOrDefault());

            var OffDiscountPrice = (itemWithMoreQty.FirstOrDefault().ItemQuantity - minimumCommonQtyinBoth) * unitPrice;

            return OffDiscountPrice + OnDiscountPrice;

        }


    }
}
