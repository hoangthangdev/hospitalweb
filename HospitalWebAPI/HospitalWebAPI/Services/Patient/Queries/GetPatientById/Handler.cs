using BuildingBlocks.Pagination;
using BuildingCore.CQRS;
using BuildingCore.Data;
using HospitalWebAPI.Dtos;
using HospitalWebAPI.Services.Customer.Queries.GetCustomerById;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebAPI.Services.Patient.Queries.GetPatientById
{
    public class Handler(IApplicationDbContext dbContext)
    : IQueryHandler<GetPatientByIdQuery, GetPatientByIdResult>
    {
        public async Task<GetPatientByIdResult> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken)
        {
            var patientResult = await dbContext.Patients
                .Where(item => query.Request.Id == item.Id)
                .Include(item => item.User)
                .FirstOrDefaultAsync(cancellationToken) ?? throw new KeyNotFoundException();

            var userResult = await dbContext.Users
                .Where(item => patientResult.User.Id == item.Id)
                .FirstOrDefaultAsync(cancellationToken) ?? throw new KeyNotFoundException();

            return new(new GetPatientByIdResponse(userResult.FullName, userResult.Address));
        }
    }
}