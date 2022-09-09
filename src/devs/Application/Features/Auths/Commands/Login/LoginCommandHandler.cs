using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public LoginCommandHandler(IUserService userService, IAuthService authService, AuthBusinessRules authBusinessRules)
        {
            _userService = userService;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetByEmail(request.UserForLoginDto.Email);
            await _authBusinessRules.UserShouldBeExists(user);
            await _authBusinessRules.UserPasswordShouldBeMatch(user.Id,request.UserForLoginDto.Password);

            AccessToken accessToken = await _authService.CreateAccessToken(user);
            RefreshToken refreshToken = await _authService.CreateRefreshToken(user,request.ipAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(refreshToken);
            LoginDto loginDto = new()
            {
                AccessToken = accessToken,
                RefreshToken = addedRefreshToken
            };
            return loginDto;

        }
    }
}
