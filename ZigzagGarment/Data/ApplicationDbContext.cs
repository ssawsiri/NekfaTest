using Microsoft.EntityFrameworkCore;
using ZigzagGarment.Models;

namespace ZigzagGarment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeExperience> EmployeeExperiences { get; set; }
    }
}
