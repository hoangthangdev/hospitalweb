using BuildingCore.CQRS;
using BuildingCore.Data;
using BuildingCore.Data.Model;
using HospitalWebAPI.Services.Auth.Commands.Requests;
using HospitalWebAPI.Services.Auth.Commands.Responses;
using static BuildingCore.Common.Constants;

namespace HospitalWebAPI.Services.Auth.Commands.Handlers
{
    public class RegisterHandler(UserManager<ApplicationUser> userManager,
                    IEmailSender<ApplicationUser> emailSender,
                    IHttpContextAccessor httpContextAccessor,
                    IApplicationDbContext context) : ICommandHandler<RegisterCommand, RegisterResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IEmailSender<ApplicationUser> _emailSender = emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IApplicationDbContext _context = context;

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
                await _userManager.AddToRoleAsync(user, RoleConstants.Doctor);
                var employee = new Employee
                {
                    DoctorId = user.Id,
                };
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync(cancellationToken);

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
                var confirmationLink = Microsoft.AspNetCore.Http.Extensions.UriHelper.BuildAbsolute(requestUrl?.Scheme ?? string.Empty,
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
