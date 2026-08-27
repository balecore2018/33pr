using ChatStudents_Shapovalov.Classes.Common;
using ChatStudents_Shapovalov.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatStudents_Shapovalov.Classes
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public UsersContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Config.config);
    }
}
