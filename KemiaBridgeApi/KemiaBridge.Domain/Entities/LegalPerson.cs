using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("legal_person")]
    public class LegalPerson : Person
    {
        public string FederalRegister { get; private set; }
        public string CorporateReason { get; private set; }

        #pragma warning disable CS8618
        public LegalPerson() { }

        public LegalPerson(string name, string email, string phone, int addressId, string federalRegister, string corporateReason)
            : base(name, email, phone, addressId)
        {
            FederalRegister = federalRegister;
            CorporateReason = corporateReason;
        }   
    }
}
