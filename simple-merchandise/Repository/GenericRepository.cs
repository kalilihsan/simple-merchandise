using simple_merchandise.Context;

namespace simple_merchandise.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly SupplierContext context;

        public GenericRepository(SupplierContext supplierContext)
        {
            context = supplierContext;
        }
        public void Add<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            context.Set<T>().Remove(entity);
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
