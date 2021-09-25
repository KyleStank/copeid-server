using System;
using System.ComponentModel.DataAnnotations;

using CopeID.Models.Documents;

namespace CopeID.Models.Photographs
{
    public class Photograph : Entity
    {
        [Required]
        public Guid DocumentId { get; set; }
        public virtual Document Document { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
