using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response
{
    public class BaseResponse
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }

        public BaseResponse()
        {
            StatusCode = "200";
            Message = "Success";
        }
    }
}
