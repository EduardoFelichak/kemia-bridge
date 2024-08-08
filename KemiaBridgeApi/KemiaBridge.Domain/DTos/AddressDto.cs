namespace KemiaBridge.Domain.DTos
{
    public class AddressDto
    {
        public int Id { get; private set; }
        public string ZipCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        public void setNewId(int id)
        {
            Id = id;
        }
    }
}
