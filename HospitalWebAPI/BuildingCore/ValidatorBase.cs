using BuildingCore.Data;
using FluentValidation;
using FluentValidation.Results;

namespace BuildingCore
{
    public class ValidatorBase<T> : AbstractValidator<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public ValidatorBase(ApplicationDbContext context)
        {
            _context = context;
        }
        protected override void RaiseValidationException(ValidationContext<T> context, ValidationResult result)
        {
            throw new ValidationException(result.Errors);
        }
    }
}
