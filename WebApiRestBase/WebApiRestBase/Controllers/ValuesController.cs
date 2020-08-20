using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using WebApiRestBase.Security;

namespace WebApiRestBase.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [Authorize(Roles = "Administrator,User")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Authorize(Roles = "Administrator,User")]
        public string Get(int id)
        {
            // TODO: Make this as a Util
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userDetails = claims.Where(p => p.Type == JwtUtility.USER_DETAILS_CLAIM).FirstOrDefault()?.Value;
            return userDetails;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
