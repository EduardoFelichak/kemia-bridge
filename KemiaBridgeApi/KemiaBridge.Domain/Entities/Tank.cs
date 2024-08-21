using KemiaBridge.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("tank")]
    public class Tank
    {
        [Key]
        public int TankId { get; private set; } 
        public TankType Type { get; private set; }
        public string Tag { get; private set; }
        public string Description { get; private set; }
        [ForeignKey(nameof(Step))]
        public int StepId { get; private set; }

        #pragma warning disable CS8618
        public Tank() { }

        public Tank(int tankId, TankType type, string tag, string description, int stepId)
        {
            TankId      = tankId;
            Type        = type;
            Tag         = tag;
            Description = description;
            StepId      = stepId;
        }
    }
}
