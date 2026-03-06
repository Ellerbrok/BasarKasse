using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Articles.Commands;

public class CreateArticle
{
    public class Command : IRequest<string>
    {
        public required Article Article { get; set; }
    }

    public class Handler(AddDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Articles.Add(request.Article);
            
            await context.SaveChangesAsync(cancellationToken);

            return request.Article.Id;
        }
    }
}
