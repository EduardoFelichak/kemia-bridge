namespace KemiaBridge.Domain.DTos
{
    public class StationDto
    {
        public int StationId { get; private set; }
        public string? Name { get; set; }
        public DateTime OperationDate { get; set; }
        public int AddressId { get; private set; }

        public void SetNewId(int id)
        {
            StationId = id;
        }

        public void SetAddressId(int id)
        {
            AddressId = id;
        }
    }
}
