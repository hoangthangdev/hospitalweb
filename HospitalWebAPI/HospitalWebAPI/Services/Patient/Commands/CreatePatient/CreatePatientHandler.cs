using BuildingCore.Constant;
using BuildingCore.CQRS;
using BuildingCore.Data;
using BuildingCore.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace HospitalWebAPI.Services.Patient.Commands.CreatePatient;

public class CreatePatientHandler(IApplicationDbContext dbContext) : ICommandHandler<CreatePatientCommand, CreatePatientResult>
{
    public async Task<CreatePatientResult> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var doctorRole = dbContext.Roles
            .FirstOrDefault(itemRole => itemRole.Name == Roles.Doctor.ToString());
        var newUser = new User()
        {
            UserName = request.createPatientRequest.FullName,
            BirthDate = request.createPatientRequest.BirthDay,
            Address = request.createPatientRequest.Address,
            Email = request.createPatientRequest.Email,
        };

        var newPatient = new PatientInfo() 
        {
            User = newUser,
        };

        dbContext.Users.Add(newUser);
        dbContext.Patients.Add(newPatient);

        var newUserRole = new IdentityUserRole<int>()
        {
            RoleId = doctorRole.Id,
            UserId = newUser.Id,
        };

        var numberChange = await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatePatientResult(newPatient.Id);
    }
}
