﻿using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Processor.Interface
{
    public interface IBillHandler
    {
        double GenerateBill(AddItemRequestModel item);
    }
}