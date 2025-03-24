using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Election
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Election_Id { get; set; }

        required
        public string Name
        { get; set; }

        required
        public string Summary
        { get; set; }

        required
        public DateTime start_date { get; set; }

        required
        public DateTime end_date { get; set; }

        required
        public DateTime created_at { get; set; }
    }
}
