using LMSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LMSAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }
        //tables  
        public DbSet<User> User { get; set; }
        public DbSet<StudentCourseMapping> StudentCourseMapping { get; set; }
        public DbSet<Course> Course { get; set; }

    }
}
