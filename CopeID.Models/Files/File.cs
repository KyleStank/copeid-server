using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CopeID.Models.Files
{
    public class File : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Path { get; set; }

        [NotMapped]
        public string Data { get; set; }
    }
}
