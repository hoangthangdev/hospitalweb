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
            // Todo: Implement the logic to get the orders
            var patientResult = await dbContext.Patients.Where(item => query.Request.Id == item.Id).FirstOrDefaultAsync(cancellationToken);
            if(patientResult == null)
            {
                throw new KeyNotFoundException();
            }

            var userResult = await dbContext.Users.Where(item => patientResult.UserId == item.Id).FirstOrDefaultAsync(cancellationToken);
            return new (new GetPatientByIdResponse(patientResult.FullName, userResult.Address));
        }
    }
}