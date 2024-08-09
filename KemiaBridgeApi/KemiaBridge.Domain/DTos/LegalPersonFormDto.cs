namespace KemiaBridge.Domain.DTos
{
    public class LegalPersonFormDto
    {
        public LegalPersonDto LegalPersonDto { get; set; } = new LegalPersonDto();
        public AddressDto AddressDto { get; set; } = new AddressDto();
    }
}
