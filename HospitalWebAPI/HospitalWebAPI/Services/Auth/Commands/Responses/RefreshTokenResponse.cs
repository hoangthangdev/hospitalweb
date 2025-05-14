namespace HospitalWebAPI.Services.Auth.Commands.Responses
{
    public record RefreshTokenResponse(
        string AccessToken,
        string RefreshToken
    );
}
