using System;
using Domain;
using Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ArticlesController(AddDbContext context) : BaseAPIController
{
    [HttpGet]
    public async Task<ActionResult<List<Article>>> GetArticles()
    {
        return await context.Articles.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticleDetail(string id)
    {
        var article = await context.Articles.FindAsync(id);
        if (article == null) return NotFound();
        return article;
    }

    [HttpGet("customeritems/{id}")]
    public async Task<ActionResult<List<Article>>> GetCustomerItems(string id)
    {
        return await context.Articles
            .Where(article => article.CustomerId == id)
            .ToListAsync();   

    }

    [HttpGet("customertotal/{id}")]
    public async Task<ActionResult<CustomerTotal>> GetCustomerTotal(string id)
    {
        var items = await context.Articles
            .Where(article => article.CustomerId == id)
            .ToListAsync();   

        if (items == null || items.Count == 0) 
            return NotFound();

        var customerTotal = new CustomerTotal
        {
            CustomerId = id,
            ArticleCount = items.Count,
            TotalAmount = items.Sum(item => item.Price)
        };

        return customerTotal;
    }
}
