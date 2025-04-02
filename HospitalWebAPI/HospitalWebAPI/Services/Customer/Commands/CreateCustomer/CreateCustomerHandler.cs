using BuildingCore.CQRS;
using BuildingCore.Data;
using BuildingCore.Data.Model;
using HospitalWebAPI.Dtos;
using System.Net;

namespace HospitalWebAPI.Services.Customer.Commands.CreateCustomer;

public class CreateCustomerHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var newCust = new CustomerModel
        {
            Id = command.Cust.Id
        };
        dbContext.Customers.Add(newCust);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateCustomerResult(newCust.Id);
    }
}