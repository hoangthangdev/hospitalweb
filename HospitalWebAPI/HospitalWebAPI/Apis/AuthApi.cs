
using HospitalWebAPI.Services.Auth.Commands.Requests;
using HospitalWebAPI.Services.Auth.Commands.Responses;
using HospitalWebAPI.Services.Auth.Queries.Handlers;

namespace HospitalWebAPI.Apis
{
    public static class AuthApi
    {
        public static void UseAuthEndPoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("api/Auth").WithTags("Auth");
            group.MapPost("login", Login);
            group.MapPost("register", Register);
            group.MapGet("confirm-email", ConfirmEmail);
            group.MapPost("refresh-token", RefreshToken);

        }

        private static async Task<LoginResponse> Login(IMediator mediator, LoginCommand command)
        {
            var result = await mediator.Send(command);
            return result;
        }

        private static async Task<RegisterResponse?> Register(IMediator mediator, RegisterCommand command)
        {
            var result = await mediator.Send(command);
            return result;
        }

        private static async Task<ConfirmEmailResult> ConfirmEmail(IMediator mediator, string userID, string token)
        {
            var result = await mediator.Send(new ConfirmEmailQuery(userID, token));
            return result;
        }
        private static async Task<RefreshTokenResponse> RefreshToken(IMediator mediator, RefreshTokenCommand command)
        {
            var result = await mediator.Send(command);
            return result;
        }
    }
}
