using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request.Merchandise
{
    public class AddNewMerchandiseReqObj
    {
        public string MerchandiseTypeCode { get; set; }
        public decimal Price { get; set; }
    }
}
