using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int PersonId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        #pragma warning disable CS8618 
        public Person() { }

        public Person(string name, string email, string phone)
        {
            Name       = name;
            Email      = email;
            Phone      = phone;
        }
    }
}
