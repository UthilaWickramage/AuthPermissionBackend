using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAuthAPI.Requests;

namespace UserAuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly JWTUtil _util;
        public AuthController(ApplicationDBContext dBContext, JWTUtil util)
        {
            _dbContext = dBContext;
            _util = util;
        }

        [HttpPost("register")]
        public async Task<ActionResult> register(RegisterRequest registerRequest)
        {
            var role = await _dbContext.UserRoles.FindAsync(registerRequest.UserRoleId);
            if (role is null) {
                return BadRequest();
            }

            Model.User user = new Model.User
            {
                UserName = registerRequest.UserName,
                UserEmail = registerRequest.UserEmail,
                Password = registerRequest.Password,
                UserRole = role

            };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("login")]
        public async Task<ActionResult> login(LoginRequest loginRequest)
        {
            var user = await _dbContext.Users.Include(u=>u.UserRole).ThenInclude(u=>u.UserRolePermissions).ThenInclude(urp => urp.Permission).FirstOrDefaultAsync(u=>u.UserName== loginRequest.Username && u.Password == loginRequest.Password);
            if(user is null)
            {
          return Unauthorized();

            }
           string token =  await _util.GenerateJwtToken(user);
            return Ok(token);
        }
    }
}
