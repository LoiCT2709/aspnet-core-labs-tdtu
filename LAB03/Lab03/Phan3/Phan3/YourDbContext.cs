using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan3
{
    public class YourDbContext:DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=703-04\SQLEXPRESS; Database=YourDB; Trusted_Connection=True; TrustServerCertificate=True");
        }

    }
}
