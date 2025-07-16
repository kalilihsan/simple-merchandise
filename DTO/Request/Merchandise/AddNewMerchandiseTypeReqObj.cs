using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request.Merchandise
{
    public class AddNewMerchandiseTypeReqObj
    {
        public string MerchandiseTypeCode { get; set; }
        public string MerchandiseTypeName { get; set; }
        public string SupplierCode { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
