using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain;
using Persistence;

namespace Application.Articles.Queries;

public class GetArticleList
{
    public class Query : IRequest<List<Article>>
    {
    }

    public class Handler(AddDbContext context) : IRequestHandler<Query, List<Article>>
    {
        public async Task<List<Article>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Articles.ToListAsync(cancellationToken);
        }
    }
}
