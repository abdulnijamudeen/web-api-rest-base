using ServiceLayer.Form;
using ServiceLayer.Mapper;
using ServiceLayer.Service.User;
using System.Web.Helpers;
using System.Web.Http;
using WebApiRestBase.Security;

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
            var token = JwtUtility.CreateToken(existingUser);
            var user = AuthMapper.LoginMap(existingUser, token);
            return Ok(user); 
        }
    }
}
