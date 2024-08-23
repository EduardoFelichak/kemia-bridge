using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("blower")]
    public class Blower
    {
        [Key]
        public int BlowerId { get; private set; }
        public string Tag { get; private set; }
        public string Description { get; private set; }
        [ForeignKey(nameof(Step))]
        public int StepId { get; private set; }

        #pragma warning disable CS8618
        public Blower() { }

        public Blower(int blowerId, string tag, string description, int stepId)
        {
            BlowerId    = blowerId;
            Tag         = tag;
            Description = description;
            StepId      = stepId;
        }
    }
}
