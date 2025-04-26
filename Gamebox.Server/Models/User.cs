using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gamebox.Server.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("oauth_id")]
        public string? OAuthId { get; set; }
        [BsonElement("username")]
        public string? Username { get; set; }
    }
}
