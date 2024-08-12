using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("person_station")]
    public class PersonStation
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = new Person();

        public int StationId { get; set; }
        public Station Station { get; set; } = new Station();
    }
}
