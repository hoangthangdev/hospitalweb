using BuildingCore.CQRS;
using BuildingCore.Data.Identity;
using BuildingCore.Interfaces;
using HospitalWebAPI.Services.Auth.Commands.Requests;
using HospitalWebAPI.Services.Auth.Commands.Responses;
using Microsoft.AspNetCore.Identity;

namespace HospitalWebAPI.Services.Auth.Commands.Handlers
{
    public class RegisterHandler : ICommandHandler<RegisterCommand, RegisterResponse>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public RegisterHandler(SignInManager<ApplicationUser> signInManager,
                        UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
            };
            var result = _userManager.CreateAsync(user, request.Password);
            if (result.Result.Succeeded)
            {
                var token = _jwtTokenGenerator.GenerateToken(user);
                return Task.FromResult(new RegisterResponse
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Token = token,
                });
            }
            return Task.FromResult<RegisterResponse>(null);
        }
    }

}
