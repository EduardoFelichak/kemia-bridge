using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("sensor_reading")]
    public class SensorReading
    {
        [Key]
        public int SensorReadingId { get; private set; }
        public DateTime ReadingDate { get; private set; }
        public double Data { get; private set; }
        public int SensorId { get; private set; }
        public int UserId { get; private set; }

        public SensorReading() { }

        public SensorReading(DateTime readingDate, double data, int sensorId, int userId)
        {
            ReadingDate = readingDate;
            Data = data;
            SensorId = sensorId;
            UserId = userId;
        }
    }
}
