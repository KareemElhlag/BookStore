using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class AuthorModel
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? AuthorName { get; set; }
    }
}
