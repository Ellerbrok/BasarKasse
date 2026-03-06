using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Articles.Commands;

public class DeleteArticle
{
    public class Command : IRequest
    {
        public required string Id { get; set; }
    }

    public class Handler(AddDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var article = await context.Articles
                .FindAsync([request.Id], cancellationToken)
                    ?? throw new Exception("Article not found");

            context.Remove(article);
            
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
