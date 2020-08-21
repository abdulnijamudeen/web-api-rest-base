using DataAccessLayer.EF;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ServiceLayer.Mapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiRestBase.Security
{
    public class JwtUtility
    {
        // TODO : Fetch From Web.config
        //public static string SigningKey = WebConfigurationManager.AppSettings["SigningKey"];
        //public static string TokenIssuer = WebConfigurationManager.AppSettings["TokenIssuer"];
        //public static string TokenAudience = WebConfigurationManager.AppSettings["TokenAudience"];

        public static string SigningKey = "SigningKey this is my custom Secret key for authnetication";
        public static string TokenIssuer = "https://localhost:44353";
        public static string TokenAudience = "https://localhost:44353";
        public static string TokenLifetimeInMinutes = "30";

        public static SecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey));
        public static SigningCredentials SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
        
        public static string USER_DETAILS_CLAIM = "App_UserDetails";
        public static string USER_ID_CLAIM = "App_UserId";
        public static string USER_ROLE_CLAIM = "App_UserRole";

        public static string CreateToken(User user)
        {
            //Ref: https://www.c-sharpcorner.com/article/asp-net-web-api-2-creating-and-validating-jwt-json-web-token/

            var userDetailsClaim = AuthMapper.UserDetailsClaimMap(user);
            string userDetails = JsonConvert.SerializeObject(userDetailsClaim);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim(ClaimTypes.Role, user.Role));
            
            permClaims.Add(new Claim(USER_ID_CLAIM, user.Id.ToString()));
            permClaims.Add(new Claim(USER_DETAILS_CLAIM, userDetails));
            permClaims.Add(new Claim(USER_ROLE_CLAIM, user.Role));

            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(
                TokenIssuer, //Issure    
                TokenAudience,  //Audience    
                permClaims,
                expires: DateTime.Now.AddMinutes(double.Parse(TokenLifetimeInMinutes)),
                signingCredentials: SigningCredentials
                );
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt_token;
        }
    }
}