using Microsoft.EntityFrameworkCore;

namespace API
{
    public class MyDbContext : DbContext
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<PriceDB> Price { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory).EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
           optionsBuilder.UseSqlServer("Server=localhost;Database=Parking_DB;Integrated Security=SSPI;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceDB>()
                .HasKey(p => p.id);
        }
    }

    public class PriceDB
    {
        public int id { get; set; }
        public decimal price { get; set; }

    }

}
