
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.Models.Repository
{
    public class AuthorRepoWithDBcontext : IBaseRepoBookAuthor<AuthorModel>
    {
        BookDbReposcs Db;
        public AuthorRepoWithDBcontext(BookDbReposcs _Db)
        {
           Db= _Db;
        }
        public void Add(AuthorModel entity)
        {
            
            Db.Authors.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int? Id)
        {
            Db.Authors.Remove(Find(Id));
            Db.SaveChanges();
        }

        public AuthorModel Find(int? Id)
        {
            var Author = Db.Authors.SingleOrDefault(F => F.Id == Id);
            return Author;
        }

        public IList<AuthorModel> List()
        {
            return Db.Authors.ToList();

        }

        public List<AuthorModel> Search(string trem)
        {
            return Db.Authors.Where(b => b.AuthorName.Contains(trem)).ToList();

        }

        public void Update(int id, AuthorModel author)
        {
            Db.Authors.Update(author);
            Db.SaveChanges();
        }
    }
}

