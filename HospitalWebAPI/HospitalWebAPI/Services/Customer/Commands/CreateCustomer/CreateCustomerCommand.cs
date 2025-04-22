using BuildingCore.CQRS;
using HospitalWebAPI.Dtos;

namespace HospitalWebAPI.Services.Customer.Commands.CreateCustomer;
public record CreateCustomerCommand(CustomerDto Cust)
    : ICommand<CreateCustomerResult>;

public record CreateCustomerResult(string? name);

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Cust.Name).NotEmpty().WithMessage("Name is required");
    }
}