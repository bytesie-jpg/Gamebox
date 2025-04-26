using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gamebox.Server.Models
{
    public class SimpleGame
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("id")]
        public string? Id { get; init; }
        [BsonElement("title")]
        public string? Title { get; set; }
        [BsonElement("image_url")]
        public string? ImageUrl { get; set; }
    }
}
