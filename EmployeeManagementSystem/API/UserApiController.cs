using System.Web.Http;
using EmployeeManagementSystem.BLL;

namespace EmployeeManagementSystem.API
{
    public class UserApiController : ApiController
    {
        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Login(LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Username and password are required.");
            }

            UserBLL userBLL =
                new UserBLL();

            int userId =
                userBLL.Login(
                    request.Username,
                    request.Password);

            if (userId <= 0)
            {
                return Unauthorized();
            }

            return Ok(new
            {
                UserId = userId,
                Username = request.Username
            });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}