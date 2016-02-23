using Microsoft.Owin;

namespace Build93.MultiTenancy.Contracts
{
    public interface ITenantResolver<TKey>
    {
        ITenant<TKey> ResolveTenant(IOwinContext context);
    }
}
