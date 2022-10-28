using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using VivaioInCloud.Common.Options;

namespace VivaioInCloud.Common.ServiceExtensions
{
    public static class ConfigureAuth
    {
        public static IServiceCollection AddPublicKeyAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<RsaSecurityKey>(provider =>
            {
                // It's required to register the RSA key with depedency injection.
                // If you don't do this, the RSA instance will be prematurely disposed.
                RSA rsa = RSA.Create();
                rsa.ImportRSAPublicKey(
                    source: Convert.FromBase64String(configuration["Jwt:PublicKey"]),
                    bytesRead: out int _
                );
                return new RsaSecurityKey(rsa);
            });
            
            Action<JwtBearerOptions> jwtBearerOptions = options =>
            {
                SecurityKey rsa = services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>();

                options.IncludeErrorDetails = true; // <- great for debugging

                // Configure the actual Bearer validation
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = rsa,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireSignedTokens = true
                };
            };
            
            services.AddOptions<JwtBearerOptions>().Configure(jwtBearerOptions);
            
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwtBearerOptions);
            



            return services;
        }


        public static IServiceCollection AddPublicAndPrivateKeyAuth<TDbCtx, TUser, TRole>(this IServiceCollection services, IConfiguration configuration)
            where TDbCtx : DbContext
            where TUser : IdentityUser
            where TRole : IdentityRole
        {
            services.AddIdentity<TUser, TRole>()
                .AddEntityFrameworkStores<TDbCtx>()
                .AddDefaultTokenProviders();

            services.AddSingleton<SigningCredentials>(provider =>
            {
                // It's required to register the RSA key with depedency injection.
                // If you don't do this, the RSA instance will be prematurely disposed.
                RSA rsa = RSA.Create();

                rsa.ImportRSAPrivateKey(
                    source: Convert.FromBase64String(configuration["Jwt:PrivateKey"]),
                    bytesRead: out int _);

                SigningCredentials signingCredentials = new SigningCredentials(
                    key: new RsaSecurityKey(rsa),
                    algorithm: SecurityAlgorithms.RsaSha256
                );

                return signingCredentials;
            });

            services.AddSingleton<RsaSecurityKey>(provider =>
            {
                // It's required to register the RSA key with depedency injection.
                // If you don't do this, the RSA instance will be prematurely disposed.
                RSA rsa = RSA.Create();
                rsa.ImportRSAPublicKey(
                    source: Convert.FromBase64String(configuration["Jwt:PublicKey"]),
                    bytesRead: out int _
                );

                return new RsaSecurityKey(rsa);
            });

            // Adding Authentication //////////////////////////////////////////////////////////////////// 
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer ////////////////////////////////////////////////////////////////////
            .AddJwtBearer(jwtOptions =>
            {
                SecurityKey securityKey = services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>();

                jwtOptions.IncludeErrorDetails = true;
                jwtOptions.SaveToken = true;
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireSignedTokens = true
                };
            });

            services.AddOptions<AccessTokenOptions>()
                .Configure(options =>
                {
                    options.Audience = configuration["JWT:Audience"];
                    options.Issuer = configuration["JWT:Issuer"];
                    options.AccessTokenExpirationHours = Convert.ToInt32(configuration["JWT:AccessTokenExpirationHours"]);
                    options.RefreshTokenExpirationDays = Convert.ToInt32(configuration["JWT:RefreshTokenExpirationDays"]);
                });

            return services;
        }
    }
}
