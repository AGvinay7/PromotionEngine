using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Models;
using PromotionEngines.Models;
using PromotionEngines.Processor.Interface;
using PromotionEngines.Utils.ActivePromotions.Impl;
using PromotionEngines.Utils.UnitPriceForSKUIDs.Impl;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PromotionEngines.Processor
{
    public class SKUItemsProcessor : ISKUItemsProcessor
    {
        private IBillHandler _billHandler;

        public SKUItemsProcessor(IBillHandler billHandler)
        {
            _billHandler = billHandler;
        }

        public double TotalOfCAndD { get; private set; }

        public AddItemResponseModel AddItemsToCart(IList<AddItemRequestModel> addItemRequestModel)
        {
            var response = new AddItemResponseModel();
            response.ItemsPurchased = addItemRequestModel.Select(item => item.ItemType).Distinct().ToList();
            double SubTotal = 0.0;

            ProcessCandDifPresent(ref addItemRequestModel); // check if items of type C or D present and Bill based on their count

            foreach (var item in addItemRequestModel)
            {
                var BilledItem = _billHandler.GenerateBill(item);
                SubTotal += BilledItem.Total;
                response.IsPromoApplied = BilledItem.IsPromoApplied;
            }
            response.Total = SubTotal + TotalOfCAndD;
            response.Date = DateTime.Now;
            return response;
        }

        private void ProcessCandDifPresent(ref IList<AddItemRequestModel> addItemRequestModel)
        {
            var C = addItemRequestModel.Where(order => order.ItemType.Contains("C", StringComparison.InvariantCultureIgnoreCase));
            var D = addItemRequestModel.Where(order => order.ItemType.Contains("D", StringComparison.InvariantCultureIgnoreCase));
            if (C.Any() && D.Any())
            {
                IList<AddItemRequestModel> C_And_D = new List<AddItemRequestModel>() { C.FirstOrDefault(), D.FirstOrDefault() };
                TotalOfCAndD = _billHandler.GenerateBillForCAndD(C_And_D);
                addItemRequestModel.Remove(C.FirstOrDefault());
                addItemRequestModel.Remove(D.FirstOrDefault());

            }

        }

        public ActionResult<ActivePromotionsModel> GetActivePromotions(string itemName)
        {
            var returnObject = new ActivePromotionsModel();
            var promotionForItem = new DiscountsFactory().GetPromotions(itemName);
            returnObject.DiscountRunning = promotionForItem.DiscountOffered;
            returnObject.ItemName = itemName;
            returnObject.NoOfItems = promotionForItem.NoOfItems;
            return returnObject;
        }

        public ActionResult<SKUItem> GetSKUItem(string id)
        {
            var returnObject = new SKUItem();
            var SKUitem = new UnitPriceFactory().GetUnitPrice(id);
            returnObject.UnitPrice = SKUitem.GetUnitPrice();
            returnObject.UnitName = SKUitem.GetUnitName();
            return returnObject;

        }
    }
}
