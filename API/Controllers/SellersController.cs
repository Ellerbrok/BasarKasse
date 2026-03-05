using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Sellers.Queries;

namespace API.Controllers;

public class SellersController : BaseAPIController
{
    [HttpGet]
    public async Task<ActionResult<List<Seller>>> GetSellers()
    {
        return await Mediator.Send(new GetSellerList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Seller>> GetSellerDetail(string id)
    {
        return await Mediator.Send(new GetSellerDetails.Query { Id = id });
    }
}
