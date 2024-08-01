using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserAuthAPI.Model;

namespace UserAuthAPI
{
    public class JWTUtil
    {
        private readonly IConfiguration _configuration;

        public JWTUtil(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GenerateJwtToken(User user)
        {

            var claims = new List<Claim>
                {
                    new Claim("Username", user.UserName),
                    new Claim("Role", user.UserRole.UserRoleName),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                    // Add permissions as a single claim or multiple claims
                    new Claim("Permissions", string.Join(",", user.UserRole.UserRolePermissions.Select(rp => rp.Permission.PermissionName)))
                };

            //What is the best way

            //HashSet<string> permissions = user.UserRole.UserRolePermissions
            //    .Select(rp => rp.Permission.PermissionName).ToHashSet();

            //foreach (var permission in permissions)
            //{
            //    claims.Add(new Claim("Permissions",permission));
            //}

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
