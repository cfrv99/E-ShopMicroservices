using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.Commons.Common.Domains.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
