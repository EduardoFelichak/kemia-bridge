﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("station")]
    public class Station
    {
        [Key]
        public int StationId { get; private set; }
        public string Name { get; private set; }
        public DateOnly OperationDate { get; private set; }
        [ForeignKey(nameof(Address))]
        public int AddressId { get; private set; }
        public Address Address { get; private set; }

        public ICollection<Step> Steps { get; set; }
        public ICollection<PersonStation> PersonStations { get; set; }
        public ICollection<Activity> Activities { get; set; }

        #pragma warning disable CS8618
        public Station() { }

        public Station(int stationId, string name, DateOnly operationDate, int personId, int addressId)
        {
            StationId     = stationId;
            Name          = name;
            OperationDate = operationDate;
            AddressId     = addressId;
        }
    }
}
