using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Models;
using PromotionEngine.Processor.Interface;

namespace PromotionEngine.Controllers
{
    
    [ApiController]
    public class PromotionEngine : ControllerBase
    {
        private ISKUItemsProcessor _sKUItemsProcessor;
        public PromotionEngine(ISKUItemsProcessor sKUItemsProcessor)
        {
            _sKUItemsProcessor = sKUItemsProcessor;
        }

        /// <summary>
        /// Get All items in the cart
        /// </summary>
        /// <returns>all items in the cart</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet]
        [Route("api/GetAllItems")]
        public ActionResult<IEnumerable<string>> GetAllItems()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get Requested item in the cart
        /// </summary>
        /// <returns> Get Requested item in the cart</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet]
        [Route("api/GetSKUItem/{id}")]
        public ActionResult<string> GetSKUItem(int id)
        {
            return "value";
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
            if(addItemRequestModel.Count != 0)
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
