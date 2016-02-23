namespace Build93.MultiTenancy.Contracts
{
    public interface ITenant<TKey>
    {
        TKey Id { get; }
        string Name { get; }
    }
}
