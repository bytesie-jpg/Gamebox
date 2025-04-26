using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Gamebox.Server.Models
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; init; }
        [BsonElement("title")]
        public string? Title { get; set; }
        [BsonElement("release_date")]
        public DateOnly? ReleaseDate { get; set; }
        [BsonElement("description")]
        public string? Description { get; set; }
        [BsonElement("image_url")]
        public string? ImageUrl { get; set; }
        [BsonElement("genre")]
        public string? Genre { get; set; }
    }
}
