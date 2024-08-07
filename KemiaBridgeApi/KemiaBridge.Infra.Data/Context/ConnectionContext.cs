using KemiaBridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KemiaBridge.Infra.Data.Context
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(new ConfigurationBuilder()
                .AddJsonFile("appsettings.local.json", optional: false, reloadOnChange: true)
                .Build()
                .GetConnectionString("DefaultConnection"));
    }
}
