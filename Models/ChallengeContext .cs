﻿using Microsoft.EntityFrameworkCore;



namespace TennisLadder.Models
{
    public class ChallengeContext : DbContext
    {
      public ChallengeContext(DbContextOptions<ChallengeContext> options) : base (options) { }
        public DbSet<Challenge> Challenges { get; set; } = null!;
    }
    
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Participant>().HasData(
    //        new Participant { Id = 1, Name = "Maxwell Dee Anderson", Email = "maxwell@gg.com", Rank = 1, Wins = 5, Loses = 2, Availability = DayOfWeek.Monday, MatchPending = false }
    //

    //        );
    //}
}