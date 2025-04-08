using Gamebox.Server.Models;
using Microsoft.Extensions.Options;
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
                gameboxDatabaseSettings.Value.RatingCollectionName);
        }

        public async Task<Rating?> GetRatingById(string id) =>
            await _ratingsCollection.Find(rating => rating.Id == id).FirstOrDefaultAsync();

    }
}
