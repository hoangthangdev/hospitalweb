using HospitalWebAPI.Dtos;
using HospitalWebAPI.Services.Customer.Commands.CreateCustomer;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebAPI.Controllers
{
    //Todo : Implement the CustomerController
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto customer)
        {
            var result = await _mediator.Send(new CreateCustomerCommand(customer));
            return Ok(result);
        }
    }
}
