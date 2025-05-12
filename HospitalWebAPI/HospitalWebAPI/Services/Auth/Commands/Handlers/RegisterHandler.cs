using BuildingCore.CQRS;
using BuildingCore.Data.Identity;
using BuildingCore.Interfaces;
using HospitalWebAPI.Services.Auth.Commands.Requests;
using HospitalWebAPI.Services.Auth.Commands.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace HospitalWebAPI.Services.Auth.Commands.Handlers
{
    public class RegisterHandler : ICommandHandler<RegisterCommand, RegisterResponse>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor; // Add IHttpContextAccessor

        public RegisterHandler(SignInManager<ApplicationUser> signInManager,
                        UserManager<ApplicationUser> userManager,
                        IJwtTokenGenerator jwtTokenGenerator,
                        IEmailSender emailSender,
                        IHttpContextAccessor httpContextAccessor) // Inject IHttpContextAccessor
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor; // Assign IHttpContextAccessor
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
            };

            var tokenEmail = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            // Use UriHelper to generate the confirmation link
            var requestUrl = _httpContextAccessor.HttpContext?.Request;
            var confirmationLink = Microsoft.AspNetCore.Http.Extensions.UriHelper.BuildAbsolute(
                requestUrl?.Scheme,
                requestUrl.Host,
                requestUrl.PathBase,
                $"/Account/ConfirmEmail?userId={user.Id}&token={Uri.EscapeDataString(tokenEmail)}");

            await _emailSender.SendEmailAsync(user,);

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                var token = _jwtTokenGenerator.GenerateToken(user);
                return new RegisterResponse
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Token = token,
                };
            }
            return null;
        }
    }

}
