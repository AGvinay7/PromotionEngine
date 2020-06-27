using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Models;
using PromotionEngines.Models;
using System.Collections.Generic;

namespace PromotionEngines.Processor.Interface
{
    public interface ISKUItemsProcessor
    {
        AddItemResponseModel AddItemsToCart(IList<AddItemRequestModel> addItemRequestModel);
        ActionResult<ActivePromotionsModel> GetActivePromotions(string itemName);
        ActionResult<SKUItem> GetSKUItem(string id);
    }
}
