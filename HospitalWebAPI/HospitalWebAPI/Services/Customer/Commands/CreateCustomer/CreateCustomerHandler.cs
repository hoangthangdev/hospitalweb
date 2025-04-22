using BuildingCore.CQRS;
using BuildingCore.Data;
using BuildingCore.Data.Model;
using System.Security.Claims;

namespace HospitalWebAPI.Services.Customer.Commands.CreateCustomer;

public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand, CreateCustomerResult>
{
    private readonly ApplicationDbContext _context;
    private readonly ClaimsPrincipal claimsPrincipal;
    public CreateCustomerHandler(ApplicationDbContext context, ClaimsPrincipal claimsPrincipal)
    {
        _context = context;
        this.claimsPrincipal = claimsPrincipal;
    }
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var newCust = new CustomerModel
        {
            Name = command.Cust.Name
        };
        _context.Customers.Add(newCust);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateCustomerResult(newCust.Name);
    }
}