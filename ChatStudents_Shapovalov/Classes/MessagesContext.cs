using ChatStudents_Shapovalov.Classes.Common;
using ChatStudents_Shapovalov.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatStudents_Shapovalov.Classes
{
    public class MessagesContext : DbContext
    {
        /// <summary>Данные из БД</summary>
        public DbSet<Messages> Messages { get; set; }

        /// <summary>Конструктор контекста</summary>
        public MessagesContext() =>
            Database.EnsureCreated();

        /// <summary>Конфигурация подключения</summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            // Говорим что используем SQL Server со следующей конфигурацией
            optionsBuilder.UseSqlServer(Config.config);
    }
}
