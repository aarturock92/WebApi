﻿using System.Security.Claims;
using System.Security.Principal;

namespace CEMEX.API.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserId(this IIdentity identity)
        {
            var ident = identity as ClaimsIdentity;
            if (ident != null)
            {
                var claim = ident.FindFirst(ClaimTypes.NameIdentifier);
                if (claim !=null)
                {
                    return claim.Value;
                }
            }

            return null;
        }
    }
}