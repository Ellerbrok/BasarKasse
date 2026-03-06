using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Sellers.Commands;

public class DeleteSeller
{
    public class Command : IRequest
    {
        public required string Id { get; set; }
    }

    public class Handler(AddDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var seller = await context.Sellers
                .FindAsync([request.Id], cancellationToken)
                    ?? throw new Exception("Seller not found");

            context.Remove(seller);
            
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
