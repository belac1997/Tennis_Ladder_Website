using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TennisLadder.Data;
using System;
using System.Linq;

namespace TennisLadder.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        { 
            using (var context = new TennisLadderContext(
                serviceProvider.GetRequiredService<DbContextOptions<TennisLadderContext>>()))
            {
                if (context.Participants.Any())
                {
                    return;
                }
                context.Participants.AddRange(
                     new Participant { Name = "Maxwell Dee Anderson", Email = "maxwell@tennis.com", Rank = 1, Wins = 5, Loses = 2, Availability = 1, MatchPending = false },
                     new Participant { Name = "John Doe", Email = "john@tennis.com", Rank = 2, Wins = 4, Loses = 1, Availability = 2, MatchPending = false },
                     new Participant { Name = "Mary Jane", Email = "mary@tennis.com", Rank = 3, Wins = 2, Loses = 19, Availability = 3, MatchPending = false }
                    );
                context.SaveChanges();
            }
        }
    }
}
