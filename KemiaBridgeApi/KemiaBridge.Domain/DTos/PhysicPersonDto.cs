using KemiaBridge.Domain.Enums;

namespace KemiaBridge.Domain.DTos
{
    public class PhysicPersonDto : PersonDto
    {
        public string RegisterCode { get; set; } = null!;
        public string? SocialName { get; set; }
        public DateTime BornAt { get; set; }
        public Gender Gender { get; set; }
    }
}
