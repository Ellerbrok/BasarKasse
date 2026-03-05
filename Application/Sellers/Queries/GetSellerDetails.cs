using Domain;
using MediatR;
using Persistence;

namespace Application.Sellers.Queries;

public class GetSellerDetails
{
    public class Query : IRequest<Seller>
    {
        public required string Id { get; set; }  
    }

    public class Handler(AddDbContext context) : IRequestHandler<Query, Seller>
    {
        public async Task<Seller> Handle(Query request, CancellationToken cancellationToken)
        {
            var seller = await context.Sellers.FindAsync([request.Id], cancellationToken);
            if( seller == null) throw new Exception("Seller not found");
            return seller;
        }
    }
}
