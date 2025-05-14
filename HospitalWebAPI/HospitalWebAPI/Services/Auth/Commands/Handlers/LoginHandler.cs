using BuildingCore.CQRS;
using BuildingCore.Interfaces;
using HospitalWebAPI.Services.Auth.Commands.Requests;
using HospitalWebAPI.Services.Auth.Commands.Responses;

namespace HospitalWebAPI.Services.Auth.Commands.Handlers
{
    public class LoginHandler : ICommandHandler<LoginCommand, LoginResponse>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public LoginHandler(SignInManager<ApplicationUser> signInManager,
                        UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return null;
            }
            var result = _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Result.Succeeded)
            {
                var token = _jwtTokenGenerator.GenerateToken(user);
                var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

                await _userManager.SetAuthenticationTokenAsync(user, "app", "RefreshToken", refreshToken);
                return new LoginResponse
                {
                    Email = user.Email,
                    Token = token,
                    RefreshToken = refreshToken
                };
            }
            return null;
        }
    }
}
