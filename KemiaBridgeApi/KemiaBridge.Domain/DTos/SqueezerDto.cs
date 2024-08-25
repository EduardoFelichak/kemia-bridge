namespace KemiaBridge.Domain.DTos
{
    public class SqueezerDto
    {
        public int SqueezerId { get; private set; }
        public string? Tag { get; set; } 
        public string? Description { get; set; }
        public int StepId { get; set; }

        public void SetNewId(int id)
        {
            SqueezerId = id;
        }
    }
}
