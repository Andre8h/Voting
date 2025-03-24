using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Votes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Vote_Id { get; set; }


        required
        public int Candidate_Id
        { get; set; }


        required
        public int Voter
        { get; set; }


        required
        public DateTime created_at { get; set; }


        required
        public int election_id { get; set; }
    }
}
