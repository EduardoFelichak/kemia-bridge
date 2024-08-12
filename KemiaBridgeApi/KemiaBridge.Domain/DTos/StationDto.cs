namespace KemiaBridge.Domain.DTos
{
    public class StationDto
    {
        public int StationId { get; private set; }
        public string? Name { get; set; }
        public DateTime OperationDate { get; set; }
        public int PersonId { get; set; }
        public int AddressId { get; set; }

        public void setNewId(int id)
        {
            StationId = id;
        }
    }
}
