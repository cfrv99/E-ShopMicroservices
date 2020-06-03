using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservice.Microservices.ProductService.Application.Commons.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string message,object key):base($"Entity \"{message}\" ({key}) was not found")
        {

        }
    }
}
