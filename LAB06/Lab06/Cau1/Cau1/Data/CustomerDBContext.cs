using Microsoft.EntityFrameworkCore;
using Cau1.Models;

namespace Cau1.Data
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
