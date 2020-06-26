using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Models;
using PromotionEngines.Models;
using PromotionEngines.Processor.Interface;

namespace PromotionEngines.Controllers
{

    [ApiController]
    public class PromotionEngineController : ControllerBase
    {
        private ISKUItemsProcessor _sKUItemsProcessor;
        public PromotionEngineController(ISKUItemsProcessor sKUItemsProcessor)
        {
            _sKUItemsProcessor = sKUItemsProcessor;
        }

        /// <summary>
        /// Active Promotions for an Item
        /// </summary>
        /// <returns>Active Promotions for an Item</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet]
        [Route("api/GetActivePromotions/{itemName}")]
        public ActionResult<ActivePromotionsModel> GetAllActivePromotions(string itemName)
        {
           return string.IsNullOrEmpty(itemName) ? null : _sKUItemsProcessor.GetActivePromotions(itemName);
        }

        /// <summary>
        /// Get Item details by itemName
        /// </summary>
        /// <returns> Get Item details by itemName</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet]
        [Route("api/GetSKUItem/{id}")]
        public ActionResult<SKUItem> GetSKUItem(string id)
        {
            return string.IsNullOrEmpty(id) ? null : _sKUItemsProcessor.GetSKUItem(id);
        }

        /// <summary>
        /// Add item to the cart
        /// </summary>
        /// <returns> Add item to the cart</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost]
        [Route("api/AddSKUItems")]
        public ActionResult<AddItemResponseModel> AddSKUItems([FromBody] IList<AddItemRequestModel> addItemRequestModel)
        {
            if (addItemRequestModel.Count != 0)
            {
                return _sKUItemsProcessor.AddItemsToCart(addItemRequestModel);
            }
            else
            {
                return null;
            }

        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/UpdateSKUItems/{id}")]
        public void UpdateSKUItems(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("api/DeleteSKUItems/{id}")]
        public bool DeleteSKUItems(int id)
        {
            return true;
        }
    }
}
