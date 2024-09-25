namespace GolfApi.Models
{
    // Model class for representing a player
    public class Player
    {
        // ID of the player
        public int PlayerID { get; set; }

        // First name of the player
        public string? FirstName { get; set; }

        // Last name of the player
        public string? LastName { get; set; }

        // Handicap of the player
        public double Handicap { get; set; }

        // Navigation property: collection of rounds associated with this player
        public ICollection<Round>? Rounds { get; set; }
    }
}
