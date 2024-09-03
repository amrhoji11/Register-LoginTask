using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models.Data
{
    public class ApplecationDbContext:DbContext
    {
        public ApplecationDbContext(DbContextOptions<ApplecationDbContext> options)
        : base(options)
        {
        }
       public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
