namespace KemiaBridge.Domain.DTos
{
    public class SensorDto
    {
        public int SensorId { get; private set; }
        public int Type { get; set; }
        public string Tag { get; set; } = null!;
        public int Status { get; set; }
        public int StepId { get; private set; }

        public void setNewId(int id)
        {
            SensorId = id;
        }

        public void setStepId(int id)
        {
            StepId = id;
        }
    }
}
