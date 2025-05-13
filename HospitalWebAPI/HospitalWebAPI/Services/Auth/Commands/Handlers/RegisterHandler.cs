using BuildingCore.CQRS;
using BuildingCore.Interfaces;
using HospitalWebAPI.Services.Auth.Commands.Requests;
using HospitalWebAPI.Services.Auth.Commands.Responses;

namespace HospitalWebAPI.Services.Auth.Commands.Handlers
{
    public class RegisterHandler : ICommandHandler<RegisterCommand, RegisterResponse>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailSender<ApplicationUser> _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterHandler(SignInManager<ApplicationUser> signInManager,
                        UserManager<ApplicationUser> userManager,
                        IJwtTokenGenerator jwtTokenGenerator,
                        IEmailSender<ApplicationUser> emailSender,
                        IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                var tokenEmail = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                // Use UriHelper to generate the confirmation link  
                var requestUrl = _httpContextAccessor.HttpContext?.Request;
                var userId = Uri.EscapeDataString(user.Id);
                var token = Uri.EscapeDataString(tokenEmail);

                var queryParameters = new List<KeyValuePair<string, string?>>
                                         {
                                             new KeyValuePair<string, string?>("userId", userId),
                                             new KeyValuePair<string, string?>("token", token)
                                         };
                var confirmationLink = Microsoft.AspNetCore.Http.Extensions.UriHelper.BuildAbsolute(requestUrl?.Scheme,
                                                                                                    requestUrl.Host,
                                                                                                    requestUrl.PathBase,
                                                                                                    "/Api/Auth/ConfirmEmail",
                                                                                                    QueryString.Create(queryParameters));
                await _emailSender.SendConfirmationLinkAsync(user, request.Email, confirmationLink);
                return new RegisterResponse(true);
            }
            return new RegisterResponse(false);
        }
    }

}
