using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Sellers.Commands;

public class CreateSeller
{
    public class Command : IRequest<string>
    {
        public required Seller Seller { get; set; }
    }

    public class Handler(AddDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Sellers.Add(request.Seller);
            
            await context.SaveChangesAsync(cancellationToken);

            return request.Seller.Id;
        }
    }
}
