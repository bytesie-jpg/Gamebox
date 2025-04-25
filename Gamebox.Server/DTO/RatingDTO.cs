namespace Gamebox.Server.DTO
{
    public class RatingDTO
    {
        public string? UserId { get; set; }
        public int? Difficulty { get; set; }
        public int? Innovation { get; set; }
        public int? Gameplay { get; set; }
        public int? Story { get; set; }
        public int? Visuals { get; set; }
        public int? Replayability { get; set; }
        public bool? Gifted { get; set; }
        public string? Review { get; set; }
    }
}
