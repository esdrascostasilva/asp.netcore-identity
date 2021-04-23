using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Extensions
{
    public class PermissionNecessary : IAuthorizationRequirement
    {
        public string Permission { get; }

        public PermissionNecessary(string permission)
        {
            Permission = permission;
        }
    }

    public class PermissionNecessaryHandler : AuthorizationHandler<PermissionNecessary>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionNecessary requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Permission" && c.Value.Contains(requirement.Permission)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
