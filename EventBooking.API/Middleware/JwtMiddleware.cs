using EventBooking.API.Models;
using EventBooking.Application.Interface.Persistence;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EventBooking.API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
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
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret ?? string.Empty);
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
