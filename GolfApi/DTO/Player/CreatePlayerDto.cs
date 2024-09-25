namespace GolfApi.DTO.Player
{
    // DTO (Data Transfer Object) for creating a player
    public class CreatePlayerDto
    {
        // First name of the player
        public string FirstName { get; set; }

        // Last name of the player
        public string LastName { get; set; }

        // Handicap of the player
        public double Handicap { get; set; }
    }
}
