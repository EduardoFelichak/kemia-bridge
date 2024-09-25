namespace KemiaBridge.Domain.DTos
{
    public class LegalPersonDto : PersonDto
    {
        public string FederalRegister { get; set; } = null!;
        public string CorporateReason { get; set; } = null!;
    }
}
