using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class BookModel
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public String? ImagUrl { get; set; }
        [ForeignKey("AuthorId")]
        public AuthorModel? Author { get; set; }
        public int? AuthorId { get; set; }

    }
}
