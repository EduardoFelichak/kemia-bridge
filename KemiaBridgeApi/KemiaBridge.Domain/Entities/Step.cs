﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("step")]
    public class Step
    {
        [Key]
        public int StepId { get; private set; }
        public string Name { get; private set; }
        public string Icon { get; private set; }
        [ForeignKey(nameof(Station))]
        public int StationId { get; private set; }
        public Station Station { get; private set; }

        public ICollection<Tank> Tanks { get; set; }
        public ICollection<Blower> Blowers { get; set; }
        public ICollection<Squeezer> Squeezers { get; set; }
        public ICollection<Sensor> Sensors { get; set; }

        #pragma warning disable CS8618
        public Step() { }

        public Step(string name, int stationId) 
        {
            Name      = name;
            StationId = stationId;
        }
    }
}
