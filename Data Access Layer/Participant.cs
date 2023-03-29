using System.Collections.Generic;

namespace MyDemoAPI
{
    public class Participant
    {
        public int Id { get; set; }
        public String Name { get; set; } = "";
        public String Email { get; set; } = "";
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public DayOfWeek Availability { get; set; }
        public bool MatchPending { get; set; }


 //       public Participant(int id, string name, string email, int rank, int wins, int loses, DayOfWeek availability, bool matchPending)
 //       {
 //           Id = id;
 //           Name = name;
 //           Email = email;
 //           Rank = rank;
 //           Wins = wins;
 //           Loses = loses;
 //           Availability = availability;
 //           MatchPending = matchPending;
 //       }

        public static List<Participant> GetParticipants()
        {
            var participants = new List<Participant>()
            {
                new Participant { Id = 1, Name = "Maxwell Dee Anderson", Email = "maxwell@tennis.com", Rank = 1, Wins = 5, Loses = 2, Availability = DayOfWeek.Monday, MatchPending = false},
                new Participant { Id = 2, Name = "John Doe", Email = "john@tennis.com", Rank = 2, Wins = 4, Loses = 1, Availability = DayOfWeek.Saturday, MatchPending = false},
                new Participant { Id = 3, Name = "Mary Jane", Email = "mary@tennis.com", Rank = 3, Wins = 2, Loses = 19, Availability = DayOfWeek.Friday, MatchPending = false}
            };
            return participants;
        }



    }
}