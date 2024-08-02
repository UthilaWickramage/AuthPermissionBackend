using System.ComponentModel.DataAnnotations;
using UserAuthAPI.Model;

namespace UserAuthAPI.Requests
{
    public class RegisterRequest
    {

        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }

        public int UserRoleId { get; set; }
    }
}
