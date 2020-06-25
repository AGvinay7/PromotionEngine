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

        public object AddItemsToCart(IList<AddItemRequestModel> addItemRequestModel)
        {
            double TotalAmount = 0;

            foreach(var item in addItemRequestModel)
            {
                TotalAmount = _billHandler.GenerateBill(item);
            }

            return TotalAmount;
        }
    }
}
