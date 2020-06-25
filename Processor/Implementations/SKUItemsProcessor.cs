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
        public object AddItemsToCart(IList<AddItemRequestModel> addItemRequestModel)
        {
            var input = addItemRequestModel;

            return new object();
        }
    }
}
