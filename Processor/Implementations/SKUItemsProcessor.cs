using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Models;
using PromotionEngines.Models;
using PromotionEngines.Processor.Interface;
using PromotionEngines.Utils.ActivePromotions.Impl;
using PromotionEngines.Utils.Constants;
using PromotionEngines.Utils.UnitPriceForSKUIDs.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngines.Processor
{
    public class SKUItemsProcessor : ISKUItemsProcessor
    {
        private IBillHandler _billHandler;

        public SKUItemsProcessor(IBillHandler billHandler)
        {
            _billHandler = billHandler;
        }

        public AddItemResponseModel AddItemsToCart(IList<AddItemRequestModel> addItemRequestModel)
        {
            var response = new AddItemResponseModel();

            double SubTotal = 0.0;

            /* isItemDpresent = addItemRequestModel.Any(a => a.ItemType == Constants.ItemD);
            isItemCpresent = addItemRequestModel.Any(a => a.ItemType == Constants.ItemC); */

            foreach (var item in addItemRequestModel)
            {                  
                
                var BilledItem = _billHandler.GenerateBill(item);
                SubTotal += BilledItem.Total;
                response.IsPromoApplied = BilledItem.IsPromoApplied;
                response.ItemsPurchased.Add(item.ItemType);
            }
            response.ItemsPurchased = response.ItemsPurchased.Distinct().ToList();
            response.Total = SubTotal;
            response.Date = DateTime.Now;
            return response;
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
