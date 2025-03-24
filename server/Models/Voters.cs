using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Voters
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        required
        public string Name
        { get; set; }

        required
        public int Dependency { get; set; }

        required
        public string Email
        { get; set; }

        required
        public string Password_hash
        { get; set; }


        required
        public DateTime created_at { get; set; }


        required
        public int election_id { get; set; }
    }
}
