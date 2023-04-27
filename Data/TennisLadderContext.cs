using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TennisLadder.Models;

namespace TennisLadder.Data
{
    public class TennisLadderContext : DbContext
    {
        public TennisLadderContext (DbContextOptions<TennisLadderContext> options)
            : base(options)
        {
        }

        public DbSet<TennisLadder.Models.Participant> Participants { get; set; } = default!;
    }
}
