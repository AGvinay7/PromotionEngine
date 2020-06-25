using PromotionEngine.Models;
using PromotionEngine.Processor.Interface;
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
            foreach (var item in addItemRequestModel)
            {
                SubTotal += _billHandler.GenerateBill(item).Total;
            }
            response.Total = SubTotal;
            return response;
        }
    }
}
