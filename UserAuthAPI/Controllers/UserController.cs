using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAuthAPI.Model;

namespace UserAuthAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        public readonly ApplicationDBContext _dbContext;
        public UserController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HasPermission(Permissions.AddUser)]
        [HttpPost]
        public async Task<ActionResult> CreateUser()
        {
            //I didn't implement any logic here. just wanted to implement permission based authorization
            return Ok();
        }


        [HasPermission(Permissions.GetUsers)]
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }


        [HasPermission(Permissions.DeleteUser)]
        [HttpDelete]
        public async Task<ActionResult> DeleteUser()
        {
            return Ok();
        }
    }
}
