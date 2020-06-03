using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopMicroservices.Commons.Common.Services
{
    public interface IDateTimeService
    {
        DateTime Now();
        DateTime UtcNow();
    }
}
