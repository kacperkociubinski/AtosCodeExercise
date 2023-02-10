using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }

    public class GetCustomesrQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerContext CustomerContext;

        public GetCustomesrQueryHandler(ICustomerContext customerContext)
        {
            CustomerContext = customerContext;
        }

        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await CustomerContext.Customers.ToListAsync(cancellationToken);
        }
    }
}
