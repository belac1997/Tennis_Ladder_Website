using System.Collections.Generic;

namespace MyDemoAPI
{
    public class Challenge
    {
        public Participant? Challenger { get; set; }
        public Participant? Defender { get; set; }
        public DateTime DateTime { get; set; }
        public String Location { get; set; } = "";
        public String Winner { get; set; } = "";


     //   public bool RankChange
     //   { 
     //       get
     //       {
     //           if (Winner == Challenger.Name) return true;
     //           else return false;
     //       }  
     //   }
        public static List<Challenge> GetChallenges()
        {
            var Challenges = new List<Challenge>()
            {
                new Challenge { DateTime = new DateTime(2023, 10, 10, 5, 30, 00), Location = "YMCA"}
            };
            return Challenges;
        }








    }
}