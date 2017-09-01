using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace alexwilkinson.Auth
{
    public static class SiteAuthConfig
    {

        private readonly static string _Issuer = "Tradexc";
        private readonly static string _Audience = "http://localhost/";
        private readonly static string _TokenPath = "/api/token";

        public static IServiceCollection AddSiteAuthorization(this IServiceCollection services)
        {

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecretKey(),
                ValidateIssuer = true,
                ValidIssuer = GetIssuer(),
                ValidateAudience = true,
                ValidAudience = GetAudience(),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = tokenValidationParameters;
                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = ex =>
                    {
                        ex.NoResult();
                        ex.Response.StatusCode = 401;
                        ex.Response.ContentType = "text/plain";

                        return ex.Response.WriteAsync(ex.Exception.ToString());
                    }
                };
            });



            return services;
        }

        private static Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            if (true)
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
            }
            return Task.FromResult<ClaimsIdentity>(null);
        }

        public static SymmetricSecurityKey GetSecretKey()
        {
            const string secretKey = "006ED5DC3AB6CD0B73E30C9EDDEE9F07F5AEE1C30AE11F06C7DA5BC08E21A4130141EEE5F3A2";
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            return signingKey;
        }
        public static string GetIssuer()
        {
            return _Issuer;
        }
        public static string GetAudience()
        {
            return _Audience;
        }
        public static string GetPath()
        {
            return _TokenPath;
        }
        public static JwtIssuerOptions GetTokenOptions()
        {
            var tokenProviderOptions = new JwtIssuerOptions
            {
                Audience = GetAudience(),
                Issuer = GetIssuer(),
                SigningCredentials = new SigningCredentials(GetSecretKey(), SecurityAlgorithms.HmacSha256),

            };

            return tokenProviderOptions;
        }

    }
}
