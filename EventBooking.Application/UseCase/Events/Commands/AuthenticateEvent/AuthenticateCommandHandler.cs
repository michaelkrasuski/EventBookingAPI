using AutoMapper;
using EventBooking.Application.Dto;
using EventBooking.Application.Interface.Persistence;
using EventBooking.Application.UseCase.Bases;
using EventBooking.Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventBooking.Application.UseCase.Events.Commands.AuthenticateEvent
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, BaseResponse<AuthenticateResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<AuthenticateResponseDto>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<AuthenticateResponseDto>();

            try
            {
                var userEntity = new UserEntity { Id = Guid.NewGuid().ToString(), IsActive = true };

                var data = await _unitOfWork.Users.InsertAsync(userEntity, cancellationToken);
                
                if (data)
                {
                    var token = await GenerateJwtToken(userEntity, request.Secret!);

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

        private async Task<string> GenerateJwtToken(UserEntity user, string secret)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {

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
