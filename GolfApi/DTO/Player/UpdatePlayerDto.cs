namespace GolfApi.DTO.Player
{
    // DTO (Data Transfer Object) for updating a player
    public class UpdatePlayerDto
    {
        // Updated first name of the player
        public string FirstName { get; set; }

        // Updated last name of the player
        public string LastName { get; set; }

        // Updated handicap of the player
        public double Handicap { get; set; }
    }
}
