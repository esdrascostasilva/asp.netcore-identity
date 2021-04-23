using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Extensions
{
    public static class RazorExtensions
    {
        // Can validate an information in razor page
        public static bool IfClaim(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateClaimsUser(page.Context, claimName, claimValue);
        }

        // Can disable a button in razor page
        public static string IfClaimShow(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateClaimsUser(page.Context, claimName, claimValue) ? "" : "disabled";
        }

        // Can disable a link in razor page
        public static IHtmlContent IfClaimShow(this IHtmlContent page, HttpContext context,  string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateClaimsUser(context, claimName, claimValue) ? page : null;
        }
    }
}
