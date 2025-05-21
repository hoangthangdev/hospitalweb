using BuildingCore.CQRS;
using HospitalWebAPI.Services.Auth.Commands.Responses;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebAPI.Services.Auth.Commands.Requests
{
    public class LoginCommand : ICommand<LoginResponse>
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
