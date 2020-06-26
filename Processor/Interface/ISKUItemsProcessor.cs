using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Models;
using PromotionEngines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngines.Processor.Interface
{
    public interface ISKUItemsProcessor
    {
        AddItemResponseModel AddItemsToCart(IList<AddItemRequestModel> addItemRequestModel);
        ActionResult<ActivePromotionsModel> GetActivePromotions(string itemName);
        ActionResult<SKUItem> GetSKUItem(string id);
    }
}
