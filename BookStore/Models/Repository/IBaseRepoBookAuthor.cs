namespace BookStore.Models.Repository
{
    public interface IBaseRepoBookAuthor<TEntity>
    {
        void Add(TEntity? entity);
        void Delete(int? Id);
        TEntity Find(int? Id);
        IList<TEntity> List();
        void Update(int id, TEntity model);
        List<TEntity> Search(String trem);
    }
}
