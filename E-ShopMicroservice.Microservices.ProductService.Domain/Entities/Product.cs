using E_ShopMicroservices.Commons.Common.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservice.Microservices.ProductService.Domain.Entities
{
    public class Product : BaseEntity<int>, IAudited
    {
        public string Name { get; set; }
    }
}
