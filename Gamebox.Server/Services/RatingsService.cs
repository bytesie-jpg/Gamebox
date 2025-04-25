using Gamebox.Server.DTO;
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

        public async Task<List<Rating>> GetRecentRatings()
        {
            var builder = Builders<Rating>.Sort;
            var sort = builder.Ascending("creation_date");
            var pipeline = new EmptyPipelineDefinition<Rating>().Sort(sort).Limit(10);
            return await _ratingsCollection.Aggregate(pipeline).ToListAsync();
        }

        public async Task<List<Rating>> GetHighestRatingsWeighted()
        {
            var builder = Builders<Rating>.Sort;
            var sort = builder.Ascending("avg_rating_weighted");
            var pipeline = new EmptyPipelineDefinition<Rating>().Sort(sort).Limit(10);
            return await _ratingsCollection.Aggregate(pipeline).ToListAsync();
        }

        public async void CreateRating(RatingDTO ratingDTO)
        {
            var weightedAvg =
                (ratingDTO.Innovation +
                ratingDTO.Gameplay +
                ratingDTO.Visuals) / 3.0;
            var unweightedAvg =
                (ratingDTO.Difficulty +
                ratingDTO.Innovation +
                ratingDTO.Gameplay +
                ratingDTO.Story +
                ratingDTO.Visuals +
                ratingDTO.Replayability) / 6.0;

            var rating = new Rating()
            {
                UserId = ratingDTO.UserId,
                Difficulty = ratingDTO.Difficulty,
                Innovation = ratingDTO.Innovation,
                Gameplay = ratingDTO.Gameplay,
                Story = ratingDTO.Story,
                Visuals = ratingDTO.Visuals,
                Replayability = ratingDTO.Replayability,
                AvgRatingUnweighted = unweightedAvg,
                AvgRatingWeighted = weightedAvg,
                Gifted = ratingDTO.Gifted,
                Review = ratingDTO.Review,
                LastUpdated = DateTime.Now
            };

            await _ratingsCollection.InsertOneAsync(rating);
        }
    }
}
