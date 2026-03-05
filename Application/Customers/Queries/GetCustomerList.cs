using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain;
using Persistence;

namespace Application.Customers.Queries;

public class GetCustomerList
{
    public class Query : IRequest<List<Customer>>
    {
    }

    public class Handler(AddDbContext context) : IRequestHandler<Query, List<Customer>>
    {
        public async Task<List<Customer>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Customers.ToListAsync(cancellationToken);
        }
    }
}
