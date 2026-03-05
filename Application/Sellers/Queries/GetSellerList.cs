using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain;
using Persistence;

namespace Application.Sellers.Queries;

public class GetSellerList
{
    public class Query : IRequest<List<Seller>>
    {
    }

    public class Handler(AddDbContext context) : IRequestHandler<Query, List<Seller>>
    {
        public async Task<List<Seller>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Sellers.ToListAsync(cancellationToken);
        }
    }
}
