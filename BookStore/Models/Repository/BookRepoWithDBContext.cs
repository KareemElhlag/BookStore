using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repository
{
    public class BookRepoWithDBContext : IBaseRepoBookAuthor<BookModel>
    {
        BookDbReposcs Db;
        public BookRepoWithDBContext(BookDbReposcs _db)
        {

            Db = _db;

        }
        public void Add(BookModel entity)
        {
            try{
                Db.Books.Add(entity);
                Db.SaveChanges();
            }catch (Exception ex) {
 } 
         
        }

        public void Delete(int? Id)
        {
            var book = Find(Id);
            Db.Books.Remove(book);
            Db.SaveChanges();
        }

        public BookModel Find(int? id)
        {
            var book = Db.Books.SingleOrDefault(F => F.Id == id);
            return book;
        }

        public IList<BookModel> List()
        {
            var Books = Db.Books.Include(a=>a.Author).ToList();
            return (Books);
        }

        public void Update(int Id, BookModel NewBook)
        {
            Db.Books.Update(NewBook);
            Db.SaveChanges();

        }
        public List<BookModel> Search(String trem) {
            var result = Db.Books.Include(a => a.Author).Where(b => b.Title.Contains(trem)
            || b.Author.AuthorName.Contains(trem));
            return result.ToList();
        }
    }
}

