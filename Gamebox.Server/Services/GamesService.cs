using Gamebox.Server.DTO;
using Gamebox.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Globalization;

namespace Gamebox.Server.Services
{
    public class GamesService
    {
        private readonly IMongoCollection<Game> _gamesCollection;

        public GamesService(IOptions<GameboxDatabaseSettings> gameboxDatabaseSettings)
        {
            var mongoClient = new MongoClient(gameboxDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(gameboxDatabaseSettings.Value.DatabaseName);

            _gamesCollection = mongoDatabase.GetCollection<Game>(
                gameboxDatabaseSettings.Value.GamesCollectionName);
        }


        public async Task<Game?> GetGameById(string id)
        {
            var filter = Builders<Game>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _gamesCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async void CreateGame(GameDTO gameDTO)
        {
            var cultureInfo = new CultureInfo("de-DE");
            var game = new Game()
            {
                Title = gameDTO.Title,
                ReleaseDate = gameDTO.ReleaseDate != null? DateOnly.Parse(gameDTO.ReleaseDate) : DateOnly.MinValue,
                Description = gameDTO.Description,
                ImageUrl = "EMPTY",
                Genre = gameDTO.Genre,
            };

            await _gamesCollection.InsertOneAsync(game);
        }
    }
}
