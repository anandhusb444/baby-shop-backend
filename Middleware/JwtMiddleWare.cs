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

        public async Task Invoke(HttpContext context)
        {
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
           

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                await _next(context);
                return;
            }

            var tokenParts = authorizationHeader.Split(' ');

            if (tokenParts.Length != 2 || tokenParts[0] != "Bearer")
            {
                await _next(context);
                return;
            }

            var token = tokenParts[1];
            AttachUserContext(context, token);
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
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                    
                    
                },out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                context.Items["User"] = jwtToken;
                    
            }
            catch(SecurityTokenExpiredException)
            {
                //Console.WriteLine(ex.Message);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsync("Token expired.");
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.WriteAsync("Token validation failed.");
                return;
            }
        }
    }
}
