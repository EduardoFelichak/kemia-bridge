namespace KemiaBridge.Domain.DTos
{
    public class AddressDto
    {
        public int AddressId { get; private set; }
        public string ZipCode { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Complement { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;
        public string City { get; set; } = null!; 
        public string State { get; set; } = null!;

        public void setNewId(int id)
        {
            AddressId = id;
        }
    }
}
