using System;

namespace E_ShopMicroservices.Commons.Common.Domains.ValueObjects
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}