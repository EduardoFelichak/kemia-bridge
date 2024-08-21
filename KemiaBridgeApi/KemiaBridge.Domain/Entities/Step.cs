using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("step")]
    public class Step
    {
        [Key]
        public int StepId { get; private set; }
        public string Name { get; private set; }
        [ForeignKey(nameof(Station))]
        public int StationId { get; private set; }

        public ICollection<Tank> Tanks { get; set; }

        #pragma warning disable CS8618
        public Step() { }

        public Step(string name, int stationId) 
        {
            Name      = name;
            StationId = stationId;
        }
    }
}
