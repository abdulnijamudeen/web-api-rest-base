using ServiceLayer.Form;
using ServiceLayer.Service.User;
using System.Net.Http;
using System.Web.Http;

namespace WebApiRestBase.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("sign-up")]
        [HttpPost]
        public IHttpActionResult SignUp([FromBody]SignUp signUp)
        {
            var user = userService.AddUser(signUp); //TODO: Refactor Response
            var response = new { user.Id, user.Name, user.Username, user.Role };
            return Ok(response);
        }
    }
}
