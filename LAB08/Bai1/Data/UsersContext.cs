using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bail.Data
{
    public class UsersContext : IdentityUserContext<IdentityUser>
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=TRANKHIETLOI\\SQLEXPRESS01;Database=Lab8Db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        }
    }
}
