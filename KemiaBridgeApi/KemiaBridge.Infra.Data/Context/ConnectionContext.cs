using KemiaBridge.Domain.Entities;
using KemiaBridge.Infra.Data.Configurators;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.Data.Context
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null !;
        public DbSet<PhysicPerson> PhysicPeople { get; set; } = null!;
        public DbSet<LegalPerson> LegalPeople { get; set; } = null!;
        public DbSet<Station> Stations { get; set; } = null!;
        public DbSet<PersonStation> PersonStations { get; set; } = null!;   
        public DbSet<Step> Steps { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tank> Tanks { get; set; } = null!;
        public DbSet<Blower> Blowers { get; set; } = null!;
        public DbSet<Squeezer> Squeezers { get; set; } = null!; 
        public DbSet<Activity> Activities { get; set; } = null!;

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureModels();

            base.OnModelCreating(modelBuilder);
        }
    }
}
