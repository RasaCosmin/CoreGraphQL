using CoreGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreGraphQL.GraphQL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }                                         
}                                             