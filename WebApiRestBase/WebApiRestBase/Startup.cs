using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System.Text;
using WebApiRestBase.Security;

[assembly: OwinStartup(typeof(WebApiRestBase.Startup))]

namespace WebApiRestBase
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
               new JwtBearerAuthenticationOptions
               {
                   AuthenticationMode = AuthenticationMode.Active,
                   TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = JwtUtility.TokenIssuer, 
                       ValidAudience = JwtUtility.TokenAudience,
                       IssuerSigningKey = JwtUtility.SecurityKey
                   }
               });
        }
    }
}
