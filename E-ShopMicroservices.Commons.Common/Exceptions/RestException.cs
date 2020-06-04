using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace E_ShopMicroservices.Commons.Common.Exceptions
{
    public class RestException:Exception
    {
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public RestException(HttpStatusCode httpStatusCode,string message)
        {
            Code = httpStatusCode;
            Message = message;
        }
    }
}
