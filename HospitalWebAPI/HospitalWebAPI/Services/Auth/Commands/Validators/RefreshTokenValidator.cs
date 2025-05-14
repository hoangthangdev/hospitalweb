using HospitalWebAPI.Services.Auth.Commands.Requests;

namespace HospitalWebAPI.Services.Auth.Commands.Validators
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.UserID).NotEmpty().WithMessage("User ID is required");
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Token is required");
        }
    }
}
