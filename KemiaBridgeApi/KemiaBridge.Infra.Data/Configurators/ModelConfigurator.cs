using Microsoft.EntityFrameworkCore;
using KemiaBridge.Infra.Data.Configurators.Models;

namespace KemiaBridge.Infra.Data.Configurators
{
    public static class ModelConfigurator
    {
        public static void ConfigureModels(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfigurator());
            modelBuilder.ApplyConfiguration(new PersonConfigurator());
            modelBuilder.ApplyConfiguration(new PhysicPersonConfigurator());
            modelBuilder.ApplyConfiguration(new LegalPersonConfigurator());
            modelBuilder.ApplyConfiguration(new StationConfigurator());
            modelBuilder.ApplyConfiguration(new PersonStationConfigurator());
            modelBuilder.ApplyConfiguration(new StepConfigurator());
            modelBuilder.ApplyConfiguration(new UserConfigurator());
        }
    }
}
