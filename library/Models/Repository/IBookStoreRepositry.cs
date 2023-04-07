namespace BookStore.Models.Repository
{
    public interface IBookStoreRepositry<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(TEntity entity, int id);
        void Delete(int id);

    }
}
