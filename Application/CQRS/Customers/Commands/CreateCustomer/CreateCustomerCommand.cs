using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.CQRS.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerContext CustomerContext;

        public CreateCustomerCommandHandler(ICustomerContext customerContext)
        {
            CustomerContext = customerContext;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer()
            {
                FirstName = request.Firstname,
                Surname = request.Surname
            };

            CustomerContext.Customers.Add(customer);

            await CustomerContext.SaveChangesAsync(cancellationToken);

            return customer;
        }
    }
}
