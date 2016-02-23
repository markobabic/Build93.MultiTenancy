using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Build93.MultiTenancy
{
    public class MultiTenancyMiddleware<TKey> : OwinMiddleware
    {
        private readonly ITenantResolver<TKey> _resolver;

        public MultiTenancyMiddleware(OwinMiddleware next, ITenantResolver<TKey> resolver)
            : base(next)
        {
            _resolver = resolver;
        }


        public override async Task Invoke(IOwinContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.Set(Constants.OwinCurrentTenant, _resolver.ResolveTenant(context));

            await Next.Invoke(context);
        }

      
    }
}