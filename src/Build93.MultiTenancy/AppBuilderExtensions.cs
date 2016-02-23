using Owin;
using System;

namespace Build93.MultiTenancy
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseMultiTenancy<TKey>(this IAppBuilder app, ITenantResolver<TKey> resolver)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            if (resolver == null)
            {
                throw new ArgumentNullException("resolver");
            }

            return app.Use(typeof(MultiTenancyMiddleware<TKey>), resolver);
        }
    }
}
