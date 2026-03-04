using System;

namespace Domain;

public class Seller
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string ActivityId { get; set; }
    public int SellerID { get; set; }
    public float Commission { get; set; } = 10f;
    public float BasicFee { get; set; } = 5f;
}
