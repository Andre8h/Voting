using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class CandidateVoteCounts
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        required
        public int candidate_id { get; set; }

        required
        public int election_id { get; set; }

        required
        public int vote_count { get; set; }
    }
}
