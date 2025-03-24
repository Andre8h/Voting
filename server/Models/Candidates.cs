using Microsoft.AspNetCore.Routing.Matching;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Candidates
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Candidate_Id { get; set; }
        
        required       
        public string Name { get; set; } 

        required
        public string Association { get; set; }

        required
        public string Summary { get; set; }

        required
        public int Dependency { get; set; }

        required
        public DateTime created_at { get; set; }


        required
        public int election_id { get; set; }
    }
}
