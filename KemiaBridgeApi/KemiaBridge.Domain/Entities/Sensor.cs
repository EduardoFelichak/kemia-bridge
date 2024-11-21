using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("sensor")]
    public class Sensor
    {
        [Key]   
        public int Id { get; private set; }
        public int Type { get; private set; }
        public string Tag { get; private set; }
        public int Status { get; private set; }
        [ForeignKey(nameof(Step))]
        public int StepId { get; private set; }

#pragma warning disable CS8618

        public Sensor() { }

        public Sensor(int type, string tag, int status)
        {
            Type = type;
            Tag = tag;
            Status = status;
        }
    }
}
