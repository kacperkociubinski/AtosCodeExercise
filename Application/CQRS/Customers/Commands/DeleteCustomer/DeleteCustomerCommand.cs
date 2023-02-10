using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.CQRS.Customers.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand(int Id) : IRequest;

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerContext CustomerContext;

        public DeleteCustomerCommandHandler(ICustomerContext customerContext)
        {
            CustomerContext = customerContext;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await CustomerContext.Customers.FindAsync(new object?[] { request.Id, cancellationToken }, cancellationToken: cancellationToken);

            if (customer == null)
            {
                throw new Exception(string.Format("No found {0} with ID: {1}", nameof(Customer), request.Id));
            }

            CustomerContext.Customers.Remove(customer);

            await CustomerContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
