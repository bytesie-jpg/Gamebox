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
        private readonly GamesService _gamesService;
        private readonly UsersService _usersService;

        public RatingsService(
            IOptions<GameboxDatabaseSettings> gameboxDatabaseSettings)
        {
            var mongoClient = new MongoClient(gameboxDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(gameboxDatabaseSettings.Value.DatabaseName);

            _ratingsCollection = mongoDatabase.GetCollection<Rating>(
                gameboxDatabaseSettings.Value.RatingsCollectionName);
            _gamesService = new GamesService(gameboxDatabaseSettings);
            _usersService = new UsersService(gameboxDatabaseSettings);
        }

        public async Task<Rating?> GetRatingById(string id)
        {
            var filter = Builders<Rating>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _ratingsCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Rating>> GetRecentRatings()
        {
            var builder = Builders<Rating>.Sort;
            var sort = builder.Descending("creation_date");
            var pipeline = new EmptyPipelineDefinition<Rating>().Sort(sort).Limit(10);
            return await _ratingsCollection.Aggregate(pipeline).ToListAsync();

        }

        public async Task<List<Rating>> GetHighestRatingsWeighted()
        {
            var builder = Builders<Rating>.Sort;
            var sort = builder.Descending("avg_rating_weighted");
            var pipeline = new EmptyPipelineDefinition<Rating>().Sort(sort).Limit(10);
            return await _ratingsCollection.Aggregate(pipeline).ToListAsync();
        }

        public async Task<List<Rating>> GetRatingsByGameId(string gameId)
        {
            var filter = Builders<Rating>.Filter.Eq("game_id", gameId);
            // TODO: Add pagination
            return await _ratingsCollection.Find(filter).Limit(10).ToListAsync();
        }

        public async Task<List<Rating>> GetRatingsByUserId(string userId)
        {
            var filter = Builders<Rating>.Filter.Eq("user_id", userId);
            // TODO: Add pagination
            return await _ratingsCollection.Find(filter).Limit(10).ToListAsync();
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

            if(ratingDTO.UserId == null || ratingDTO.GameId == null)
            {
                throw new Exception("UserID or GameID is null.");
            }
            User? userResp = await _usersService.GetUserById(ratingDTO.UserId);
            Game? gameResp = await _gamesService.GetGameById(ratingDTO.GameId);
            if (userResp == null || gameResp == null)
            {
                throw new Exception("User or Game is null.");
            }
            SimpleUser user = new()
            {
                Id = userResp.Id,
                Username = userResp.Username
            };
            SimpleGame game = new()
            {
                Id = gameResp.Id,
                Title = gameResp.Title,
                ImageUrl = gameResp.ImageUrl
            };

            Rating rating = new()
            {
                User = user,
                Game = game,
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
