using Microsoft.EntityFrameworkCore;
using Task2.Model;

namespace Task2.Data
{
    public class HospitalDbContext : DbContext
    {

        public HospitalDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
