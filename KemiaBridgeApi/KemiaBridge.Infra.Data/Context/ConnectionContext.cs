using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KemiaBridge.Infra.Data.Context
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(new ConfigurationBuilder()
                .AddJsonFile("appsettings.Local.json", optional: false, reloadOnChange: true)
                .Build()
                .GetConnectionString("DefaultConnection")!);
    }
}
