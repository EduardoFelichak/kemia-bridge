using KemiaBridge.Domain.Enums;

namespace KemiaBridge.Domain.DTos
{
    public class UserDto
    {
        public int UserId { get; private set; }
        public UserTypeEnum Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public void SetNewId(int id)
        {
            UserId = id;
        }
    }
}
