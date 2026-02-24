using ARN.Pedidos.Application.Interfaces.External.JwtToken;
using ARN.Pedidos.Infrastructure.External.TokenJwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ARN.Pedidos.Infrastructure.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITokenJwtService, TokenJwtService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKeyJwt"])),
                    ValidIssuer = configuration["IsserJwt"],
                    ValidAudience = configuration["AudienceJwt"],
                };
            });

            return services;
        }
    }
}
