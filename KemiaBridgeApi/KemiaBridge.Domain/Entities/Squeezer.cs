using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("squeezer")]
    public class Squeezer
    {
        [Key]
        public int SqueezerId { get; private set; }
        public string Tag { get; private set; }
        public string Description { get; private set; }
        [ForeignKey(nameof(Step))]
        public int StepId { get; private set; }

        #pragma warning disable CS8618
        public Squeezer() { }

        public Squeezer(string tag, string description, int stepId)
        {
            Tag = tag;
            Description = description;
            StepId = stepId;
        }
    }
}
