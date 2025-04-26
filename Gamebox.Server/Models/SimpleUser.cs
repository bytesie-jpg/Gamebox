using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gamebox.Server.Models
{
    public class SimpleUser
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("id")]
        public string? Id { get; set; }
        [BsonElement("username")]
        public string? Username { get; set; }
    }
}
