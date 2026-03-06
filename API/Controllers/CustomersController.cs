using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Customers.Queries;
using Application.Customers.Commands;

namespace API.Controllers;

public class CustomersController : BaseAPIController
{
    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetCustomers()
    {
        return await Mediator.Send(new GetCustomerList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerDetail(string id)
    {
        return await Mediator.Send(new GetCustomerDetails.Query { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateCustomer(Customer customer)
    {
        return await Mediator.Send(new CreateCustomer.Command { Customer = customer });
    }

    [HttpPut]
    public async Task<ActionResult> EditCustomer(Customer customer)
    {
        await Mediator.Send(new EditCustomer.Command { Customer = customer });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(string id)
    {
        await Mediator.Send(new DeleteCustomer.Command { Id = id });
        return Ok();
    }
}
