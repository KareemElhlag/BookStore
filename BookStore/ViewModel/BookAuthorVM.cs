using BookStore.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.ViewModel
{
    public class BookAuthorVM
    {
        
        public int BookId { get; set; }

   
        public string? Title { get; set; }

        public string? Description { get; set; }

        public  IFormFile FileImg { get; set; }
        public string? imgurl { get; set; }
        public int? Price { get; set; }
        public int AuthorId { get; set; }

        public  List<AuthorModel>? Authors { get; set; }
    }
}
