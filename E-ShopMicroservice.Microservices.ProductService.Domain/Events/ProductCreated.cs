using E_ShopMicroservices.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservice.Microservices.ProductService.Domain.Events
{
    public class ProductCreated:Event
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProductCreated(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}
