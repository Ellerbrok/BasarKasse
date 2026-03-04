using System;

namespace Domain;

public class Customer
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string ActivityId { get; set; }
    public required string CashierId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
