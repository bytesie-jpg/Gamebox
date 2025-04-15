using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Gamebox.Server.Models
{
    [BsonIgnoreExtraElements]
    public class Rating
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("user_id")]
        public string? UserId {  get; set; }
        [BsonElement("difficulty")]
        public int? Difficulty { get; set; }
        [BsonElement("innovation")]
        public int? Innovation { get; set; }
        [BsonElement("gameplay")]
        public int? Gameplay { get; set; }
        [BsonElement("story")]
        public int? Story { get; set; }
        [BsonElement("replayability")]
        public int? Replayability { get; set; }
        [BsonElement("gifted")]
        public bool? Gifted { get; set; }
        [BsonElement("comment")]
        public string? Comment { get; set; }
    }
}
