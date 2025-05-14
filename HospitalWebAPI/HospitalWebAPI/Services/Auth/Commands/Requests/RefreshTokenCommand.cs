using BuildingCore.CQRS;
using HospitalWebAPI.Services.Auth.Commands.Responses;

namespace HospitalWebAPI.Services.Auth.Commands.Requests
{
    public record RefreshTokenCommand(string UserID, string RefreshToken) : ICommand<RefreshTokenResponse>;

}
