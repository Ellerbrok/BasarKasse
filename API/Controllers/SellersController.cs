using System;
using Domain;
using Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class SellersController(AddDbContext context) : BaseAPIController
{
    [HttpGet]
    public async Task<ActionResult<List<Seller>>> GetAllSellers()
    {
        return await context.Sellers.ToListAsync();
    }

    [HttpGet("activity/{activityId}")]
    public async Task<ActionResult<List<Seller>>> GetSellersFromActivity(string activityId)
    {
        return await context.Sellers
            .Where(seller => seller.ActivityId == activityId)
            .ToListAsync();     
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Seller>> GetSellerDetail(string id)
    {
        var seller = await context.Sellers.FindAsync(id);
        if (seller == null) return NotFound();
        return seller;
    }
}
