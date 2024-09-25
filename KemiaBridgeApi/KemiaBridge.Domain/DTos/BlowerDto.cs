namespace KemiaBridge.Domain.DTos
{
    public class BlowerDto
    {
        public int BlowerId { get; private set; }
        public string Tag { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int StepId { get; set; }

        public void SetNewId(int id)
        {
            BlowerId = id;
        }
    }
}
