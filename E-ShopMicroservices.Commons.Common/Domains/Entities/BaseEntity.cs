using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.Commons.Common.Domains.Entities
{
    public class BaseEntity<T> : IEntity
    {
        public T Id { get; set; }
    }
}
