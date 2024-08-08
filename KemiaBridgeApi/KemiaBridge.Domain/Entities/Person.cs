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
        [ForeignKey("Address")]
        public int AddressId { get; private set; }

        #pragma warning disable CS8618 
        public Person() { }

        public Person(string name, string email, string phone, int addressId)
        {
            Name       = name;
            Email      = email;
            Phone      = phone;
            AddressId  = addressId;
        }
    }

    [Table("physic_person")]
    public class PhysicPerson : Person
    {
        public string RegisterCode { get; private set; }
        public string SocialName { get; private set; }
        public DateTime BornAt { get; private set; }
        public int Gender { get; private set; }

        public PhysicPerson() { }

        public PhysicPerson(string name, string email, string phone, int addressId, string registerCode, string socialName, DateTime bornAt, int gender)
            : base(name, email, phone, addressId)
        {
            RegisterCode = registerCode;
            SocialName   = socialName;
            BornAt       = bornAt;
            Gender       = gender;
        }   
    }

    [Table("legal_person")]
    public class LegalPerson : Person
    {
        public string FederalRegister { get; private set; }
        public string CorporateReason { get; private set; }

        public LegalPerson() { }

        public LegalPerson(string name, string email, string phone, int addressId, string federalRegister, string corporateReason)
            : base(name, email, phone, addressId)
        {
            FederalRegister = federalRegister;
            CorporateReason = corporateReason;
        }   
    }
}
