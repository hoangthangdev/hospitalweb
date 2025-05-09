using BuildingCore.CQRS;
using HospitalWebAPI.Services.Auth.Commands.Responses;

namespace HospitalWebAPI.Services.Auth.Commands.Requests
{
    public class RegisterCommand : ICommand<RegisterResponse>
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
    }
}
