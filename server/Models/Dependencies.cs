using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Dependencies
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Dependency_iD { get; set; }

        required
        public string Name
        { get; set; }


        required
        public DateTime created_at { get; set; }
    }
}
