using KemiaBridge.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("physic_person")]
    public class PhysicPerson : Person
    {
        public string RegisterCode { get; private set; }
        public string SocialName { get; private set; }
        public DateTime BornAt { get; private set; }
        public Gender Gender { get; private set; }

        #pragma warning disable CS8618
        public PhysicPerson() { }

        public PhysicPerson(string name, string email, string phone, int addressId, string registerCode, string socialName, DateTime bornAt, Gender gender)
            : base(name, email, phone, addressId)
        {
            RegisterCode = registerCode;
            SocialName   = socialName;
            BornAt       = bornAt;
            Gender       = gender;
        }   
    }
}
