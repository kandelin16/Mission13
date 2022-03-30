using System;
using System.ComponentModel.DataAnnotations;

namespace mission13_ka.Models
{
    public class Bowler_Score
    {
        [Key]
        public int MatchID { get; set; }
        public int GameNumber { get; set; }
        public int BowlerID { get; set; }
        public int RawScore { get; set; }
        public int HandiCapScore { get; set; }
        public bool WonGame { get; set; }
    }
    public class Match_Game 
    { 
        [Key]
        public int MatchID { get; set; }
        public int GameNumber { get; set; }
        public int WinningTeamID { get; set; }
    }
    public class Tournament
    {
        [Key]
        public int TourneyID { get; set; }
        public DateTime TourneyDate { get; set; }
        public string TourneyLocation { get; set; }
    }
    public class Tourney_Match
    {
        [Key]
        public int MatchID { get; set; }
        public int TourneyID { get; set; }
        public int Lanes { get; set; }
        public int OddLaneTeamID { get; set; }
        public int EvenLaneTeamID { get; set; }
    }
}
