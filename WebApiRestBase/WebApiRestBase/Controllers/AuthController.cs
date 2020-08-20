using ServiceLayer.Form;
using ServiceLayer.Service.User;
using System.Net.Http;
using System.Web.Helpers;
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
            var existingUser = userService.GetUserByUsername(signUp.Username);
            if (existingUser != null)
                return Ok("User already exist");
            userService.AddUser(signUp);
            return Ok("User created successfully");
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody]Login login)
        {
            var existingUser = userService.GetUserByUsername(login.Username);
            if (existingUser == null)
                return Unauthorized();
            var isAuthenticated = Crypto.VerifyHashedPassword(existingUser.PasswordHash, login.Password);
            if (!isAuthenticated)
                return Unauthorized();
            //TODO : JWT Token Generator
            return Ok(new { existingUser.Id, existingUser.Name, existingUser.Username, existingUser.Role }); // Refactor to Object
        }
    }
}
