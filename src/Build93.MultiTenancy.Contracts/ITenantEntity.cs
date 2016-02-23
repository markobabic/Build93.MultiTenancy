using System;

namespace Build93.MultiTenancy.Contracts
{
    public interface ITenantEntity<TKey> where TKey : struct
    {
        Nullable<TKey> TenantId { get; set; }
    }
}
