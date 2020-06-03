using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.Commons.Common.Services
{
    public interface ICurrentUserService
    {
        long? UserId { get; }
    }
}
