using HospitalWebAPI.Dtos;
using BuildingCore.CQRS;

namespace HospitalWebAPI.Services.Patient.Commands.CreatePatient
{
    public record CreatePatientCommand(CreatePatientRequest createPatientRequest ) :ICommand<CreatePatientResult>;

    public record CreatePatientResult(int Id);

    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {
            //RuleFor(x => x.createPatientRequest.).NotEmpty().WithMessage("Name is required");
        }
    }
}
