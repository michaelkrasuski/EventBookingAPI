using EventBooking.Application.Extensions;
using EventBooking.Application.Interface.Persistence;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EventBooking.API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await AttachUserToContext(context, token, unitOfWork.Users);
            }

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, string token, IUserRepository userRepository)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var secret = _configuration.GetSecret();
                var key = Encoding.ASCII.GetBytes(secret ?? string.Empty);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

                //Attach user to context on successful JWT validation
                context.Items["User"] = await userRepository.GetAsync(userId, CancellationToken.None);
            }
            catch
            {
                //Do nothing if JWT validation fails
                // user is not attached to context so the request won't have access to secure routes
            }
        }
    }
}
