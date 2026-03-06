using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Articles.Queries;
using Application.Articles.Commands;

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

    [HttpPost]
    public async Task<ActionResult<string>> CreateArticle(Article article)
    {
        return await Mediator.Send(new CreateArticle.Command { Article = article });
    }

    [HttpPut]
    public async Task<ActionResult> EditArticle(Article article)
    {
        await Mediator.Send(new EditArticle.Command { Article = article });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteArticle(string id)
    {
        await Mediator.Send(new DeleteArticle.Command { Id = id });
        return Ok();
    }
}
