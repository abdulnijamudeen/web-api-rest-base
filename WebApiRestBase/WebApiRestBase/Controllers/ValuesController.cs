using ServiceLayer.Form;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using WebApiRestBase.Security;
using WebApiRestBase.Utility;

namespace WebApiRestBase.Controllers
{
    public class ValuesController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/values
        public IEnumerable<string> Get()
        {
            // Ref: https://stackify.com/log4net-guide-dotnet-logging/
            log.Info("Hello logging world!");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Authorize(Roles = "Administrator,User")]
        public UserDetailsClaim Get(int id)
        {
            return AppUtility.GetCurrentUserDetails();
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
