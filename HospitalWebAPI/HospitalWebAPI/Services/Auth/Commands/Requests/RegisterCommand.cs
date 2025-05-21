using BuildingCore.CQRS;
using HospitalWebAPI.Services.Auth.Commands.Responses;

namespace HospitalWebAPI.Services.Auth.Commands.Requests
{
    public class RegisterCommand : ICommand<RegisterResponse>
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
