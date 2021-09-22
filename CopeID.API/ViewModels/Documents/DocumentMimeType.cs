using System.ComponentModel.DataAnnotations;

namespace CopeID.API.ViewModels.Documents
{
    public class DocumentMimeType
    {
        [Required]
        public string MimeType { get; set; }

        public DocumentMimeType(string mimeType)
        {
            MimeType = mimeType;
        }
    }
}
