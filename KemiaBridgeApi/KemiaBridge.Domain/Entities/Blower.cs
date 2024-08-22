namespace KemiaBridge.Domain.Entities
{
    public class Blower
    {
        public int BlowerId { get; private set; }
        public string Tag { get; private set; }
        public string Description { get; private set; }
        public int StepId { get; private set; }

        #pragma warning disable CS8618
        public Blower() { }

        public Blower(int blowerId, string tag, string description, int stepId)
        {
            BlowerId    = blowerId;
            Tag         = tag;
            Description = description;
            StepId      = stepId;
        }
    }
}
