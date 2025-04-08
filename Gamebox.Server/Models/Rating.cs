using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Gamebox.Server.Models
{
    public class Rating
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
