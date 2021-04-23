using AspNetCoreIdentity.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddAuthorizationConfig(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanDelete", policy => policy.RequireClaim("CanDelete"));

                options.AddPolicy("CanRead", policy => policy.Requirements.Add(new PermissionNecessary("CanRead")));
                options.AddPolicy("CanWrite", policy => policy.Requirements.Add(new PermissionNecessary("CanWrite")));

            });

            return services;
        }
    }
}
