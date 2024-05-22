using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repository
{
    public class BookDbReposcs : DbContext
    {
        public BookDbReposcs(DbContextOptions<BookDbReposcs> options):base(options) {
            //act all the model on the project
        }

        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookModel> Books { get; set; }


    }
}
