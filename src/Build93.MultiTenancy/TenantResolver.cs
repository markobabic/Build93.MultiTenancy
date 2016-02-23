using System;
using System.Collections.Concurrent;

namespace Build93.MultiTenancy
{
    public class TenantResolver<TKey>: ITenantResolver<TKey>
    {
        private readonly Func<IOwinContext,string> _tenantIdentifier;
        private readonly Func<ITenantStore<TKey>> _store;
        private readonly ConcurrentDictionary<string,ITenant<TKey>> _tenants = new ConcurrentDictionary<string, ITenant<TKey>>();

        public TenantResolver(Func<ITenantStore<TKey>> store,Func<IOwinContext,string> tenantIdentifier)
        {
            _tenantIdentifier = tenantIdentifier;
            _store = store;
        }

        public ITenant<TKey> ResolveTenant(IOwinContext context)
        {
            var tenantIdentifier = _tenantIdentifier(context);
            return _tenants.GetOrAdd(tenantIdentifier, key => _store().Find(key));
        }

       
    }
}