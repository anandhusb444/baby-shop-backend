using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace baby_shop_backend.Services.JwtServies
{
    public class JwtServices : I_jwtServices
    {
        private IConfiguration _configuration;
        private string _securityKey;

        public JwtServices(IConfiguration config)
        {
            _configuration = config;
            _securityKey = _configuration["Jwt:Key"];
        }

        public int GetUserId(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validation = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey))
            };

            var result = tokenHandler.ValidateToken(token, validation, out var validationToken);
            if(validationToken is not JwtSecurityToken jwttoken)
            {
                throw new Exception("This token is invalid");
            }
            var userClaims = jwttoken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
            if(userClaims == null)
            {
                throw new Exception("Invalid or Missing token Id");
            }
            return Convert.ToInt32(userClaims.Value);
        }
    }
}
