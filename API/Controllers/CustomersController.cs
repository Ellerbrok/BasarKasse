using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Customers.Queries;

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
}
