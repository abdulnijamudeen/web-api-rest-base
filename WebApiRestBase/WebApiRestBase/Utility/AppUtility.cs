using Newtonsoft.Json;
using ServiceLayer.Form;
using System.Linq;
using System.Security.Claims;
using WebApiRestBase.Security;

namespace WebApiRestBase.Utility
{
    public class AppUtility
    {
        public static UserDetailsClaim GetCurrentUserDetails()
        {
            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            var userDetailsJson = claims.Where(p => p.Type == JwtUtility.USER_DETAILS_CLAIM).FirstOrDefault()?.Value;
            var userDetails = JsonConvert.DeserializeObject<UserDetailsClaim>(userDetailsJson);
            return userDetails;
        }
        //TODO: Handle Exception With log4net
        //TODO: Email Service

        //TODO: Find Best API Response strategy
    }
}