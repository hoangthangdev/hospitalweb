using BuildingCore.CQRS;
using BuildingCore.Exceptions;
using BuildingCore.Interfaces;
using HospitalWebAPI.Services.Auth.Commands.Requests;
using HospitalWebAPI.Services.Auth.Commands.Responses;

namespace HospitalWebAPI.Services.Auth.Commands.Handlers
{
    public class RefreshTokenHandler : ICommandHandler<RefreshTokenCommand, RefreshTokenResponse>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<ApplicationUser> _userManager;

        public RefreshTokenHandler(IJwtTokenGenerator jwtTokenGenerator,
            UserManager<ApplicationUser> userManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
        }

        public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserID);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            var saveRefreshToken = await _userManager.GetAuthenticationTokenAsync(user, "app", "RefreshToken");
            if (saveRefreshToken == null || !saveRefreshToken.Equals(request.RefreshToken))
            {
                throw new BadRequestException("Invalid refresh token");
            }

            var newAccessToken = _jwtTokenGenerator.GenerateToken(user);
            var newRefreshToken = _jwtTokenGenerator.GenerateRefreshToken();

            await _userManager.RemoveAuthenticationTokenAsync(user, "app", "RefreshToken");
            await _userManager.SetAuthenticationTokenAsync(user, "app", "RefreshToken", newRefreshToken);

            return new RefreshTokenResponse
            (
                newAccessToken,
                newRefreshToken
            );
        }
    }
}
