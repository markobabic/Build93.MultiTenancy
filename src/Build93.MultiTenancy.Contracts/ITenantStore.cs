namespace Build93.MultiTenancy.Contracts
{
    public interface ITenantStore<TKey>
    {
        ITenant<TKey> Find(string tenantIdentifier);
    }
}