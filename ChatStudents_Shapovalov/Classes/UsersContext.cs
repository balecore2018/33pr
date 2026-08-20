using ChatStudents_Shapovalov.Classes.Common;
using ChatStudents_Shapovalov.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatStudents_Shapovalov.Classes
{
    public class UsersContext : DbContext
    {
        /// <summary>Данные из БД</summary>
        public DbSet<Users> Users { get; set; }

        /// <summary>Конструктор контекста</summary>
        public UsersContext() =>
            // Проверяем подключены ли мы к БД, если не подключены, подключаемся
            Database.EnsureCreated();

        /// <summary>Конфигурация подключения</summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            // Говорим что используем SQL Server со следующей конфигурацией
            optionsBuilder.UseSqlServer(Config.config);
    }
}
