namespace Gamebox.Server.Models
{
    public class GameboxDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string RatingsCollectionName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
    }
}
