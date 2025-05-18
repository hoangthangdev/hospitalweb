using BuildingCore.CQRS;
using BuildingCore.Data;
using BuildingCore.Data.Model;

namespace HospitalWebAPI.Services.Patient.Commands.CreatePatient;

public class CreatePatientHandler(IApplicationDbContext dbContext) : ICommandHandler<CreatePatientCommand, CreatePatientResult>
{
    public async Task<CreatePatientResult> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {

        var newUser = new User()
        {
            BirthDate = request.createPatientRequest.birthDay,
            Address = request.createPatientRequest.Address,
        };

        var newPatient = new BuildingCore.Data.Model.PatientInfo() 
        {
            User = newUser,
        };

        dbContext.Users.Add(newUser);
        dbContext.Patients.Add(newPatient);
        var numberChange = await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatePatientResult(newPatient.Id);
    }
}
