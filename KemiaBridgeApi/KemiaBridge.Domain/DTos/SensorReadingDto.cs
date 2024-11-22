namespace KemiaBridge.Domain.DTos
{
    public class SensorReadingDto
    {
        public int SensorReadingId { get; private set; }
        public DateTime ReadingDate { get; set; }
        public double Data { get; set; }
        public int SensorId { get; private set; }
        public int UserId { get; private set; }

        public void setNewId(int id)
        {
            SensorReadingId = id;
        }

        public void setSensorId(int id)
        {
            SensorId = id;
        }

        public void setUserId(int id)
        {
            UserId = id;
        }
    }
}
