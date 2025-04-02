using BuildingBlocks.Pagination;
using BuildingCore.CQRS;
using BuildingCore.Data;
using HospitalWebAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebAPI.Services.Customer.Queries.GetCustomerById;

public class Handler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCustomerByIdQuery, GetCustomerByIdResult>
{
    public async Task<GetCustomerByIdResult> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        // Todo: Implement the logic to get the orders
        var rs = await dbContext.Customers.ToListAsync(cancellationToken);
        return new GetCustomerByIdResult(
            new PaginatedResult<CustomerDto>(
                1,
                10,
                rs.Count,
                rs.Select(x => new CustomerDto(Id:x.Id))));
    }
}