using System.Text;
using FastAcademy.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FastAcademy.API.Extensions;

public static class AuthExtensions
{
    public static void AddCoreAuth(this IServiceCollection services, JwtOptions options)
    {
        services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(
                o =>
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.TokenSigningKey));

                    o.TokenValidationParameters.IssuerSigningKey = key;
                    o.TokenValidationParameters.ValidateIssuerSigningKey = true;
                    o.TokenValidationParameters.ValidateLifetime = true;
                    o.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
                    o.TokenValidationParameters.ValidAudience = options.Audience;
                    o.TokenValidationParameters.ValidateAudience = options.Audience is not null;
                    o.TokenValidationParameters.ValidIssuer = options.Issuer;
                    o.TokenValidationParameters.ValidateIssuer = options.Audience is not null;
                });
        
        services.AddAuthorization();
    }

    public static void UseCoreAuth(this WebApplication app)
    {
        app.UseAuthentication();
        
        app.UseAuthorization();
    }
}