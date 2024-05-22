
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.Models.Repository
{
    public class AuthorRepo : IBaseRepoBookAuthor<AuthorModel>
    {
        List<AuthorModel> Authors;
        public AuthorRepo()
        {
            Authors = new List<AuthorModel>()
            {
                new AuthorModel() {
                    Id = 1, AuthorName="Qis AlMozfr"
                },
                 new AuthorModel() {
                    Id = 2, AuthorName="Abo Baker Altghlipy"
                },
                  new AuthorModel() {
                    Id = 3, AuthorName="Ayham Bin Tmim"
                },
            };
        }
        public void Add(AuthorModel entity)
        {
            entity.Id = Authors.Max(A => A.Id) + 1;
            Authors.Add(entity);
        }

        public void Delete(int? Id)
        {
            Authors.Remove(Find(Id));
        }

        public AuthorModel Find(int? Id)
        {
            var Author = Authors.SingleOrDefault(F => F.Id == Id);
            return Author;
        }

        public IList<AuthorModel> List()
        {
            return (Authors);
        }

        public List<AuthorModel> Search(string trem)
        {
            return Authors.Where(b => b.AuthorName.Contains(trem)).ToList();
        }

        public void Update(int id, AuthorModel author)
        {
            var authors = Find(id);
            authors.AuthorName = author.AuthorName;
        }
    }
}
