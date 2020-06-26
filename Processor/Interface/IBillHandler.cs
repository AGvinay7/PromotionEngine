using PromotionEngines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngines.Processor.Interface
{
    public interface IBillHandler
    {
        AddItemResponseModel GenerateBill(AddItemRequestModel item);
    }
}
