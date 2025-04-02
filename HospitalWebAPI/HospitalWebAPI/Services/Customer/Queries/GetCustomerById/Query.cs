using BuildingBlocks.Pagination;
using BuildingCore.CQRS;
using BuildingCore.Pagination;
using HospitalWebAPI.Dtos;

namespace HospitalWebAPI.Services.Customer.Queries.GetCustomerById;
public record GetCustomerByIdQuery(PaginationRequest PaginationRequest)
    : IQuery<GetCustomerByIdResult>;

public record GetCustomerByIdResult(PaginatedResult<CustomerDto> Orders);
