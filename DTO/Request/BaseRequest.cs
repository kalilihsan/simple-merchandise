using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request
{
    public class BaseRequest
    {
        public DateTime RequestDateTime { get; set; }

        public BaseRequest()
        {
            RequestDateTime = DateTime.Now;
        }
    }
}
