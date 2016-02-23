using System.Web;
using Build93.MultiTenancy.Contracts;

namespace Build93.MultiTenancy.Owin
{
    public class TenantProvider<TKey> : ITenantProvider<TKey>
    {
        public ITenant<TKey> Current
        {
            get { return HttpContext.Current != null? HttpContext.Current.GetOwinContext().Get<ITenant<TKey>>(Constants.OwinCurrentTenant) : null ;  }
        }

        public override string ToString()
        {
            return Current != null ? Current.Name : "";
        }
    }

}
