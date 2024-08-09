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
        public GenderEnum Gender { get; private set; }

        #pragma warning disable CS8618
        public PhysicPerson() { }

        public PhysicPerson(string name, string email, string phone, string registerCode, string socialName, DateTime bornAt, GenderEnum gender)
            : base(name, email, phone)
        {
            RegisterCode = registerCode;
            SocialName   = socialName;
            BornAt       = bornAt;
            Gender       = gender;
        }   
    }
}
