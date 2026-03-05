using Domain;
using MediatR;
using Persistence;

namespace Application.Articles.Queries;

public class GetArticleDetails
{
    public class Query : IRequest<Article>
    {
        public required string Id { get; set; }  
    }

    public class Handler(AddDbContext context) : IRequestHandler<Query, Article>
    {
        public async Task<Article> Handle(Query request, CancellationToken cancellationToken)
        {
            var article = await context.Articles.FindAsync([request.Id], cancellationToken);
            if( article == null) throw new Exception("Article not found");
            return article;
        }
    }
}
