namespace KemiaBridge.Domain.DTos
{
    public class PersonDto
    {
        public int PersonId { get; private set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int AddressId { get; set; }
    }
}
