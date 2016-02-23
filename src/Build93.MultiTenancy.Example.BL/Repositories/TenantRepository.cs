using System.Data.Entity;
using System.Linq;
using Build93.MultiTenancy.Contracts;
using Build93.MultiTenancy.Example.BL.Model;
using Build93.MultyTenancy.EntityFramework;

namespace Build93.MultiTenancy.Example.BL.Repositories
{
    public class TenantRepository: ITenantStore<int>
    {
        private readonly IDbSet<Tenant> _dbSet;

        public TenantRepository(IUnitOfWork uow)
        {
            _dbSet = uow.GetDbSet<Tenant>();
        }

        public ITenant<int> Find(string tenantIdentifier)
        {
            return _dbSet.FirstOrDefault(t => t.Domain == tenantIdentifier);
        }
    }
}
