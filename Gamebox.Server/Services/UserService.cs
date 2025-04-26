using Gamebox.Server.DTO;
using Gamebox.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gamebox.Server.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserService(
            IOptions<GameboxDatabaseSettings> gameboxDatabaseSettings)
        {
            var mongoClient = new MongoClient(gameboxDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(gameboxDatabaseSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<User>(
                gameboxDatabaseSettings.Value.UsersCollectionName);
        }

        public async Task<User?> Authenticate(User user)
        {
            User existing_user = await _usersCollection.Find(Builders<User>.Filter.Eq("oauth_id", user.OAuthId)).FirstAsync();
            if (existing_user == null)
            {
                try
                {
                    await _usersCollection.InsertOneAsync(user);
                    return user;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }

            } else return existing_user;
        }

        public async Task<User?> GetUserById(string id)
        {
            var filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _usersCollection.Find(filter).FirstOrDefaultAsync();
        }


        public async void CreateUser(UserDTO userDTO)
        {
            var user = new User()
            {
                OAuthId = userDTO.OAuthId,
                Username = userDTO.Username
            };

            await _usersCollection.InsertOneAsync(user);
        }
    }
}
