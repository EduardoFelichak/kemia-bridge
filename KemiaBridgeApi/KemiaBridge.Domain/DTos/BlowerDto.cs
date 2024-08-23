namespace KemiaBridge.Domain.DTos
{
    public class BlowerDto
    {
        public int BlowerId { get; private set; }
        public string Tag { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StepId { get; set; }

        public void SetNewId(int id)
        {
            BlowerId = id;
        }
    }
}
