using System;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Articles.Commands;

public class EditArticle
{
    public class Command : IRequest
    {
        public required Article Article { get; set; }
    }

    public class Handler(AddDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var article = await context.Articles.FindAsync([request.Article.Id], cancellationToken) 
                ?? throw new Exception("Article not found");

            mapper.Map(request.Article, article);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
