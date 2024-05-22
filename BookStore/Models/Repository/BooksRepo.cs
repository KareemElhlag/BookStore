
using System.Linq;

namespace BookStore.Models.Repository
{
    public class BooksRepo : IBaseRepoBookAuthor<BookModel>
    {
        List<BookModel> books;
        public BooksRepo()
        {
            books = new List<BookModel>()
            {
                new BookModel()
                {
                    Id= 1,Title="GeioPh",Description="About book Id is 1", Price=121 ,
                    Author= new AuthorModel
                    {
                        Id=1
                    } },
                 new BookModel()
                {
                    Id= 2,Title="GeioPh2",Description="About book Id is 2", Price=122 ,Author= new AuthorModel
                    {
                        Id=2
                    }
                 },
                  new BookModel()
                {
                    Id= 3,Title="GeioPh3",Description="About book Id is 3", Price=123,Author= new AuthorModel
                    {
                        Id=3

                    }
                 }
            };

        }
        public void Add(BookModel entity)
        {
            entity.Id = books.Max(x => x.Id)+1;
             books.Add(entity);
        }

        public void Delete(int? Id)
        {
            var book = Find(Id);
            books.Remove(book);
        }

        public BookModel Find(int? id)
        {
            var book = books.SingleOrDefault(F => F.Id==id);
            return book;
        }

        public IList<BookModel> List()
        {
            return (books);
        }

        public List<BookModel> Search(string trem)
        {
            return books.Where(b => b.Title.Contains(trem)).ToList();
        }

        public void Update(int Id, BookModel NewBook)
        {
            var book = Find(Id);
            book.Title = NewBook.Title;
            book.Description = NewBook.Description; 
            book.Price = NewBook.Price; 
               
        }
    }
}
