using MongoDB.Bson.Serialization.Attributes;

namespace Gamebox.Server.DTO
{
    public class UserDTO
    {
        public string? OAuthId { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
    }
}
