using System;

namespace Domain;

public class CustomerTotal
{
    public required string CustomerId { get; set; }
    public required int ArticleCount { get; set; }
    public required float TotalAmount { get; set; }
}
