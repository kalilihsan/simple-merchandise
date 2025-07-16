namespace simple_merchandise.Repository
{
    public interface IGenericRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task SaveChangesAsync();
    }
}
