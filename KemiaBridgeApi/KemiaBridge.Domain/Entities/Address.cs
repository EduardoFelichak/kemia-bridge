using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("address")]
    public class Address
    {
        [Key]
        public int AddressId { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        #pragma warning disable CS8618
        public Address() { }

        public Address(string zipcode, string street, string complement, string neighborhood, string city, string state)
        {
            ZipCode      = zipcode;
            Street       = street;
            Complement   = complement;
            Neighborhood = neighborhood;
            City         = city;
            State        = state;
        }
    }
}