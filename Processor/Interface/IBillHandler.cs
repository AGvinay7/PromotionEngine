using PromotionEngines.Models;
using System.Collections.Generic;

namespace PromotionEngines.Processor.Interface
{
    public interface IBillHandler
    {
        AddItemResponseModel GenerateBill(AddItemRequestModel item);
        double GenerateBillForCAndD(IList<AddItemRequestModel> item);

    }
}
