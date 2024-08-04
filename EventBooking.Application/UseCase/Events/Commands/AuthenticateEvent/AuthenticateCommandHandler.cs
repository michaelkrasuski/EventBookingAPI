using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using EventBooking.Application.Dto;
using EventBooking.Application.Extensions;
using EventBooking.Application.Interface.Persistence;
using EventBooking.Application.UseCase.Bases;
using EventBooking.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventBooking.Application.UseCase.Events.Commands.AuthenticateEvent
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, BaseResponse<AuthenticateResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthenticateCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<BaseResponse<AuthenticateResponseDto>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AuthenticateResponseDto>();

            try
            {
                var userEntity = new UserEntity { Id = Guid.NewGuid(), IsActive = true };

                var data = await _unitOfWork.Users.InsertAsync(userEntity, cancellationToken);

                var token = await GenerateJwtToken(userEntity);

                if (data && token is not null)
                {
                    response.Success = true;
                    response.Message = "Authentication succeed!";
                    response.Data = new AuthenticateResponseDto { Id = userEntity.Id, Token = token };
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        private async Task<string> GenerateJwtToken(UserEntity user)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                var secret = _configuration.GetSecret();

                if (secret is null)
                {
                    throw new Exception("Could not retrieve secret");
                }

                var key = Encoding.ASCII.GetBytes(secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity([new Claim("id", user?.Id?.ToString() ?? string.Empty)]),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }
    }
}
