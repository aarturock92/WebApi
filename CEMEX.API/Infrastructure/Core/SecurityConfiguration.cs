﻿using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Web.Configuration;

namespace CEMEX.API.Infrastructure.Core
{
    public static class  SecurityConfiguration
    {
        public static string SigningKey = WebConfigurationManager.AppSettings["SigningKey"];
        public static string TokenIssuer = WebConfigurationManager.AppSettings["TokenIssuer"];
        public static string TokenAudience = WebConfigurationManager.AppSettings["TokenAudience"];
        public static int TokenLifeTime = int.Parse(WebConfigurationManager.AppSettings["TokenLifetimeInMinutes"]);

        public static SecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey));
        public static SigningCredentials SigningCredential = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
    }
}