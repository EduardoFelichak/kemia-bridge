namespace KemiaBridge.Domain.DTos
{
    public class SqueezerDto
    {
        public int SqueezerId { get; private set; }
        public string Tag { get; set; } = null!;     
        public string Description { get; set; } = null!;    
        public int StepId { get; set; }

        public void SetNewId(int id)
        {
            SqueezerId = id;
        }
    }
}
