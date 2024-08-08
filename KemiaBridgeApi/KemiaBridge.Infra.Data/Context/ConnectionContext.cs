using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Configurators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KemiaBridge.Infra.Data.Context
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; } = null!;

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfigurator());

            base.OnModelCreating(modelBuilder);
        }
    }
}
