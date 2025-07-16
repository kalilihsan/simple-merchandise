using Entity;
using Microsoft.EntityFrameworkCore;

namespace simple_merchandise.Context
{
        public class SupplierContext : DbContext
        {
            public SupplierContext(DbContextOptions<SupplierContext> options) : base(options) { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                foreach (var entity in modelBuilder.Model.GetEntityTypes())
                {
                    entity.SetTableName(entity.GetTableName()!.ToLower());

                    foreach (var property in entity.GetProperties())
                    {
                        property.SetColumnName(property.GetColumnName()!.ToLower());
                    }
                }
            }

            public DbSet<Contact> Contact { get; set; }
            public DbSet<Supplier> Supplier { get; set; }
            public DbSet<MerchandiseType> MerchandiseType { get; set; }
            public DbSet<Merchandise> Merchandise { get; set; }
        }
}
