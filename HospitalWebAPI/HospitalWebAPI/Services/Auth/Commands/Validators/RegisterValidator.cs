using BuildingCore;
using BuildingCore.Data;
using HospitalWebAPI.Services.Auth.Commands.Requests;

namespace HospitalWebAPI.Services.Auth.Commands.Validators
{
    public class RegisterValidator : ValidatorBase<RegisterCommand>
    {
        public RegisterValidator(ApplicationDbContext context) : base(context)
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName is required.")
                .MinimumLength(3)
                .WithMessage("UserName must be at least 3 characters long.")
                .MaximumLength(20)
                .WithMessage("UserName must not exceed 20 characters.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .Matches("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$")
                .WithMessage("Format email invalid format  ");
            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.")
                .Matches(@"[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]")
                .WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]")
                .WithMessage("Password must contain at least one digit.")
                .Matches(@"[\W]")
                .WithMessage("Password must contain at least one special character.");
        }
    }
}
