using BuildingBlocks.Pagination;
using BuildingCore.CQRS;
using BuildingCore.Data;
using HospitalWebAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebAPI.Services.Customer.Queries.GetCustomerById;

public class Handler
    : IQueryHandler<GetCustomerByIdQuery, GetCustomerByIdResult>
{
    private readonly ApplicationDbContext _context;
    public Handler(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    public async Task<GetCustomerByIdResult> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        // Todo: Implement the logic to get the orders
        var rs = await _context.Customers.ToListAsync(cancellationToken);
        return new GetCustomerByIdResult(
            new PaginatedResult<CustomerDto>(
                1,
                10,
                rs.Count,
                rs.Select(x => new CustomerDto(Name: x.Name))));
    }
}