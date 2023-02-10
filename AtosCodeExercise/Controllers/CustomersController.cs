using Application.CQRS.Customers.Commands.CreateCustomer;
using Application.CQRS.Customers.Commands.DeleteCustomer;
using Application.CQRS.Customers.Queries.GetCustomers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CustomersController : ApiControllerBase
    {
        private const string Message = "Request action: {ActionName}";
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            _logger.LogInformation(Message, nameof(GetCustomers));

            return await Send(new GetCustomersQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            _logger.LogInformation(Message, nameof(CreateCustomer));

            return await this.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer([FromRoute] int id)
        {
            _logger.LogInformation(Message, nameof(DeleteCustomer));

            return await this.Send(new DeleteCustomerCommand(id));
        }
    }
}