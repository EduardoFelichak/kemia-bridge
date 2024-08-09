using KemiaBridge.Domain.Enums;

namespace KemiaBridge.Domain.DTos
{
    public class PhysicPersonDto : PersonDto
    {
        public string RegisterCode { get; set; } = string.Empty;
        public string SocialName { get; set; } = string.Empty;
        public DateTime BornAt { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
