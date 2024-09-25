namespace KemiaBridge.Domain.DTos
{
    public class PersonDto
    {
        public int PersonId { get; protected set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;  
        public int AddressId { get; private set; }

        public void SetNewId(int id)
        {
            PersonId = id;
        }

        public void SetAddressId(int id)
        {
            AddressId = id;
        }
    }
}
