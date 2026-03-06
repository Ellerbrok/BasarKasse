using System;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Sellers.Commands;

public class EditSeller
{
    public class Command : IRequest
    {
        public required Seller Seller { get; set; }
    }

    public class Handler(AddDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var seller = await context.Sellers.FindAsync([request.Seller.Id], cancellationToken) 
                ?? throw new Exception("Seller not found");

            mapper.Map(request.Seller, seller);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
