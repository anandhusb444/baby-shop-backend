using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace baby_shop_backend.Middleware
{
    public class JwtMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly string _secret;

        public JwtMiddleWare(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _secret = config["Jwt:Key"];
        }

        public async Task Invoke(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault().Split();

            if(token != null)
            {
                AttachUserContext(context, token);
            }

            await _next(context);
        }

        private void AttachUserContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true
                    
                },out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                context.Items["User"] = jwtToken;
                    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
