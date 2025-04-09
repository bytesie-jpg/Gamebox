using Gamebox.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gamebox.Server.Services
{
    public class RatingsService
    {
        private readonly IMongoCollection<Rating> _ratingsCollection;

        public RatingsService(
            IOptions<GameboxDatabaseSettings> gameboxDatabaseSettings)
        {
            var mongoClient = new MongoClient(gameboxDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(gameboxDatabaseSettings.Value.DatabaseName);

            _ratingsCollection = mongoDatabase.GetCollection<Rating>(
                gameboxDatabaseSettings.Value.RatingsCollectionName);
        }

        public async Task<Rating?> GetRatingById(string id)
        {
            var filter = Builders<Rating>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _ratingsCollection.Find(filter).FirstOrDefaultAsync();
        }
 
    }
}
