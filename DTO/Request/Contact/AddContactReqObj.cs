using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request.Contact
{
    public class AddContactReqObj : BaseRequest
    {
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
    }
}
