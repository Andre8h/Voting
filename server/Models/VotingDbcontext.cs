using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public class VotingDbcontext: DbContext
    {
        public VotingDbcontext(DbContextOptions<VotingDbcontext> options) : base(options)
        {

        }
        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<CandidateVoteCounts> CandidateVoteCounts { get; set; }
        public DbSet<Dependencies> Dependencies { get; set; }
        public DbSet<Election> Election { get; set; }
        public DbSet<Voters> Voters { get; set; }
        public DbSet<Votes> Votes { get; set; }



    }
}
