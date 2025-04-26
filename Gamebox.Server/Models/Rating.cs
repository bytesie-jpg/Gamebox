using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Gamebox.Server.Models
{
    [BsonIgnoreExtraElements]

    public class Rating
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; init; }
        [BsonElement("user_id")]
        public string? UserId {  get; init; }
        [BsonElement("game_id")]
        public string? GameId { get; init; }
        [BsonElement("difficulty")]
        public int? Difficulty { get; init; }
        [BsonElement("innovation")]
        public int? Innovation { get; init; }
        [BsonElement("gameplay")]
        public int? Gameplay { get; init; }
        [BsonElement("story")]
        public int? Story { get; init; }
        [BsonElement("visuals")]
        public int? Visuals { get; init; }
        [BsonElement("replayability")]
        public int? Replayability { get; init; }
        [BsonElement("avg_rating_unweighted")]
        public Double? AvgRatingUnweighted { get; init; }
        [BsonElement("avg_rating_weighted")]
        public Double? AvgRatingWeighted { get; init; }
        [BsonElement("gifted")]
        public bool? Gifted { get; init; }
        [BsonElement("review")]
        public string? Review { get; init; }
        [BsonElement("last_updated_date")]
        public DateTime LastUpdated { get; init; }
    }
}
