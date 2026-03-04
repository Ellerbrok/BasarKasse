using System;

namespace Domain;

public class Article
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string ActivityId { get; set; }
    public required string CustomerId { get; set; }
    public required string SellerId { get; set; }
    public required string ArticleId { get; set; }
    public float Price { get; set; }
}
