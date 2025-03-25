using APILabs.Models;
using Microsoft.EntityFrameworkCore;
namespace APILabs.Context
{
    public class StudentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-I125DVC\\SQLEXPRESS;Initial Catalog=APIlabs;Integrated Security=true;Encrypt=false;");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
