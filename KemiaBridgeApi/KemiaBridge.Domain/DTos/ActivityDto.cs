namespace KemiaBridge.Domain.DTos
{
    public class ActivityDto
    {
        public int ActivityId { get; private set; }
        public string Title { get; set; } = null!;
        public int Priority { get; set; }
        public DateTime LimitDate { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public int StationId { get; set; }

        public void SetNewId(int id)
        {
            ActivityId = id;
        }

        public void SetStationId(int id) 
        { 
            StationId = id; 
        }
    }
}
