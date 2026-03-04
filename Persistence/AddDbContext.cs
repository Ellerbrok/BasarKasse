using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AddDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Activity> Activities { get; set; }
    public required DbSet<Seller> Sellers { get; set; }
    public required DbSet<Customer> Customers { get; set; }
    public required DbSet<Article> Articles { get; set; }
}
