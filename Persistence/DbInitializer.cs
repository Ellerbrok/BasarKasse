using System;
using Domain;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedData(AddDbContext context)
    {
        bool bSaveChanges = false;

        if (!context.Activities.Any())
        {
            var activities = new List<Activity>
            {
                new() 
                { 
                    Id = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1", 
                    Name = "Test Basar 2024",
                    Date = new DateTime(2024, 04, 17) 
                },
                new() 
                { 
                    Id = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2", 
                    Name = "Test Basar 2025", 
                    Date = new DateTime(2025, 11, 12) 
                }
            };

            // append to the database
            context.Activities.AddRange(activities);

            // save the changes to the database      
            bSaveChanges = true; 
        }

        if (!context.Sellers.Any())
        {
            var sellers = new List<Seller>
            {
                new()
                {
                    Id = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB11",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1",
                    SellerID = 1,
                    Commission = 10f,
                    BasicFee = 5f
                },
                new()
                {
                    Id = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB12",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1",
                    SellerID = 2,
                    Commission = 10f,
                    BasicFee = 5f
                },
                new()
                {
                    Id = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB21",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    SellerID = 1,
                    Commission = 10f,
                    BasicFee = 5f
                },
                new()
                {
                    Id = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB22",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    SellerID = 2,
                    Commission = 0f,
                    BasicFee = 0f
                },
                new()
                {
                    Id = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB23",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    SellerID = 3,
                    Commission = 10f,
                    BasicFee = 10f
                }
            };

            // append to the database
            context.Sellers.AddRange(sellers);

            // save the changes to the database      
            bSaveChanges = true; 
        }

        if (!context.Customers.Any())
        {
            var customers = new List<Customer>
            {
                new()
                {
                    Id = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC11",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1",
                    CashierId = "1",
                    Date = new DateTime(2024, 04, 17, 13, 0, 0), 
                },
                new()
                {
                    Id = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC12",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1",
                    CashierId = "1",
                    Date = new DateTime(2024, 04, 17, 13, 1, 0), 
                },
                new()
                {
                    Id = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC13",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1",
                    CashierId = "2",
                    Date = new DateTime(2024, 04, 17, 14, 0, 0), 
                },
                new()
                {
                    Id = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC21",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    CashierId = "1",
                    Date = new DateTime(2025, 11, 12, 13, 0, 0), 
                },
                new()
                {
                    Id = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC22",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    CashierId = "1",
                    Date = new DateTime(2025, 11, 12, 13, 1, 0), 
                },
                new()
                {
                    Id = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC23",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    CashierId = "2",
                    Date = new DateTime(2025, 11, 12, 14, 0, 0), 
                }
            };

            // append to the database
            context.Customers.AddRange(customers);

            // save the changes to the database      
            bSaveChanges = true; 
        }

        if (!context.Articles.Any())
        {
            var articles = new List<Article>
            {
                new()
                {
                    Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDD11",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1",
                    CustomerId = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC11",
                    SellerId   = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB11",
                    ArticleId = "11",
                    Price = 10f 
                },
                new()
                {
                    Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDD12",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1",
                    CustomerId = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC12",
                    SellerId   = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB12",
                    ArticleId = "12",
                    Price = 2.5f 
                },
                new()
                {
                    Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDD13",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1",
                    CustomerId = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC13",
                    SellerId   = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB11",
                    ArticleId = "13",
                    Price = 3.5f 
                },
                new()
                {
                    Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDD14",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1",
                    CustomerId = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC13",
                    SellerId   = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB12",
                    ArticleId = "14",
                    Price = 8.5f 
                },
                new()
                {
                    Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDD21",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    CustomerId = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC21",
                    SellerId   = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB21",
                    ArticleId = "21",
                    Price = 20f 
                },
                new()
                {
                    Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDD22",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    CustomerId = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC22",
                    SellerId   = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB22",
                    ArticleId = "22",
                    Price = 12.5f 
                },
                new()
                {
                    Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDD23",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    CustomerId = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC22",
                    SellerId =   "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB23",
                    ArticleId = "23",
                    Price = 2.5f 
                },
                new()
                {
                    Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDD24",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    CustomerId = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC23",
                    SellerId = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB21",
                    ArticleId = "24",
                    Price = 5.5f 
                },
                new()
                {
                    Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDD25",
                    ActivityId = "AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2",
                    CustomerId = "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCC23",
                    SellerId = "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBB23",
                    ArticleId = "25",
                    Price = 18.5f 
                }
            };

            // append to the database
            context.Articles.AddRange(articles);

            // save the changes to the database      
            bSaveChanges = true; 
        }
        
        if (bSaveChanges)        
        {
            await context.SaveChangesAsync();
        }
    }        
}
