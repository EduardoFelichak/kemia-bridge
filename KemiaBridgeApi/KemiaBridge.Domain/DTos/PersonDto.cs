namespace KemiaBridge.Domain.DTos
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int AddressId { get; set; }
    }

    public class PhysicPersonDto : PersonDto
    {
        public string RegisterCode { get; set; } = string.Empty;
        public string SocialName { get; set; } = string.Empty;
        public DateTime BornAt { get; set; }
        public int Gender { get; set; }
    }

    public class LegalPersonDto : PersonDto
    {
        public string FederalRegister { get; set; } = string.Empty;
        public string CorporateReason { get; set; } = string.Empty;
    }
}
