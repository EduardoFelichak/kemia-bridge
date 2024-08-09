namespace KemiaBridge.Domain.DTos
{
    public class LegalPersonDto : PersonDto
    {
        public string FederalRegister { get; set; } = string.Empty;
        public string CorporateReason { get; set; } = string.Empty;

        public void setNewId(int id)
        {
            PersonId = id;
        }
    }
}
