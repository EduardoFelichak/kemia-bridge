namespace KemiaBridge.Domain.DTos
{
    public class StationDto
    {
        public int StationId { get; private set; }
        public string Name { get; set; } = null!;
        public DateOnly OperationDate { get; set; }
        public AddressDto? Address { get; set; }
        private int AddressId { get; set; }
        public ICollection<StepDto>? Steps { get; set; }

        public void SetNewId(int id)
        {
            StationId = id;
        }

        public void SetAddressId(int id)
        {
            AddressId = id;
        }
    }

    public class SmpStationDto
    {
        public int StationId { get; private set; }
        public string Name { get; set; } = null!;
        public DateOnly OperationDate { get; set; }
    }
}
