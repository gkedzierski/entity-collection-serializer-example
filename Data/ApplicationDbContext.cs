namespace EntityCollectionSerializerExample.Data
{
    using EntityCollectionSerializerExample.Comparers;
    using EntityCollectionSerializerExample.Converters;
    using EntityCollectionSerializerExample.Entities;
    using EntityCollectionSerializerExample.Enums;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var converter = new EnumCollectionJsonValueConverter<UserRole>();
            var comparer = new CollectionValueComparer<UserRole>();

            builder.Entity<User>()
                .Property(e => e.UserRoles)
                .HasConversion(converter)
                .Metadata.SetValueComparer(comparer);
        }
    }
}
