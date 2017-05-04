﻿using CEMEX.API.Infrastructure.Core;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace CEMEX.API.Infrastructure.Filters
{
    public class BearerAuthenticationFilter : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
            {
                return;
            }

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new UnauthorizedResult(null, request);
                return;
            }

            var token = authorization.Parameter;
            var validationParams = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = SecurityConfiguration.TokenIssuer,

                ValidateAudience = true,
                ValidAudience = SecurityConfiguration.TokenAudience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SecurityConfiguration.SecurityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.InboundClaimTypeMap["name"] = ClaimTypes.Name;

                SecurityToken securityToken;
                var principal = context.Principal = tokenHandler.ValidateToken(token, validationParams, out securityToken);
            }
            catch (Exception ex)
            {
                context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], request);
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}