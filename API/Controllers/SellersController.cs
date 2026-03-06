using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Sellers.Queries;
using Application.Sellers.Commands;

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

    [HttpPost]
    public async Task<ActionResult<string>> CreateSeller(Seller seller)
    {
        return await Mediator.Send(new CreateSeller.Command { Seller = seller });
    }

    [HttpPut]
    public async Task<ActionResult> EditSeller(Seller seller)
    {
        await Mediator.Send(new EditSeller.Command { Seller = seller });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSeller(string id)
    {
        await Mediator.Send(new DeleteSeller.Command { Id = id });
        return Ok();
    }
}
