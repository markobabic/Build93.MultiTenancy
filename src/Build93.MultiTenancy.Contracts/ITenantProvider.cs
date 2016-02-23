namespace Build93.MultiTenancy.Contracts
{
    public interface ITenantProvider<TKey>
    {
        ITenant<TKey> Current { get; }
    }
}