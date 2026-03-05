using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Articles.Queries;

namespace API.Controllers;

public class ArticlesController : BaseAPIController
{
    [HttpGet]
    public async Task<ActionResult<List<Article>>> GetArticles()
    {
        return await Mediator.Send(new GetArticleList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticleDetail(string id)
    {
        return await Mediator.Send(new GetArticleDetails.Query { Id = id });
    }
}
