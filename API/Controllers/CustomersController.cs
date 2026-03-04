using System;
using Domain;
using Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class CustomersController(AddDbContext context) : BaseAPIController
{
    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetCustomers()
    {
        return await context.Customers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerDetail(string id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null) return NotFound();
        return customer;
    }

}
