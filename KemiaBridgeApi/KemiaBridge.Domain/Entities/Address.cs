using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("address")]
    public class Address
    {
        [Key]
        public int Id { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        #pragma warning disable CS8618
        public Address() { }
        #pragma warning restore CS8618

        public Address(string zipcode, string street, string complement, string neighborhood, string city, string state)
        {
            this.ZipCode = zipcode;
            this.Street = street;
            this.Complement = complement;
            this.Neighborhood = neighborhood;
            this.City = city;
            this.State = state;
        }
    }
}