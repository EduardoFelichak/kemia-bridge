using KemiaBridge.Domain.Enums;

namespace KemiaBridge.Domain.DTos
{
    public class TankDto
    {
        public int TankId { get; private set; }
        public TankType Type { get; set; }
        public string Tag { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StepId { get; set; }

        public void SetNewId(int id)
        {
            TankId = id;
        }
    }
}
