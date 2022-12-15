using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
            : base("name=BookStoreDbContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Category)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Category1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User1)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User11)
                .WithOptional(e => e.User3)
                .HasForeignKey(e => e.ModifiedBy);
        }
    }
}
