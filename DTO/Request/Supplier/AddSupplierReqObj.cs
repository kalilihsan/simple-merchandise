﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request.Supplier
{
    public class AddSupplierReqObj : BaseRequest
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
    }
}
