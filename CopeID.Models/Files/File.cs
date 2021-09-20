using System.ComponentModel.DataAnnotations;

namespace CopeID.Models.Files
{
    public class File : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Path { get; set; }
    }
}
