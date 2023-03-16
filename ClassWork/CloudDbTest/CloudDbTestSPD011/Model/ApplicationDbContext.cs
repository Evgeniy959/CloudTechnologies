using Microsoft.EntityFrameworkCore;

namespace CloudDbTestSPD011.Model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ExampleTable> ExampleTable { get; set; }

        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
