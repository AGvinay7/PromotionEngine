using PromotionEngine.Models;
using PromotionEngine.Processor.Interface;
using PromotionEngine.Utils.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Processor
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
    }
}
