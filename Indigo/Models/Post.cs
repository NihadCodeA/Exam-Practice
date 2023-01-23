using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indigo.Models
{
    public class Post
    {
        public int Id { get; set; }

        [StringLength(maximumLength:40)]
        public string Title { get; set; }

        [StringLength(maximumLength:100)]
        public string Description { get; set; }

        [StringLength(maximumLength:20)]
        public string RedirectText { get; set; }
        public string RedirectUrl { get; set; }

        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
