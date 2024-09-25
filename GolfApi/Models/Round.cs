namespace GolfApi.Models
{
    // Model class for representing a round of golf
    public class Round
    {
        // ID of the round
        public int RoundID { get; set; }

        // ID of the player associated with this round
        public int PlayerID { get; set; }

        // ID of the course where the round was played
        public int CourseID { get; set; }

        // Date of the round
        public DateTime Date { get; set; }

        // Score of the round
        public int Score { get; set; }

        // Navigation property: player associated with this round
        public Player? Player { get; set; }

        // Navigation property: course where the round was played
        public Course? Course { get; set; }
    }
}
