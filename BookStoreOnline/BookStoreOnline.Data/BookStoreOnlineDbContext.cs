using BookStoreOnline.Model.Models;
using System.Data.Entity;

namespace BookStoreOnline.Data
{
    public class BookStoreOnlineDbContext : DbContext
    {
        public BookStoreOnlineDbContext() : base("BookStoreOnlineConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorProduct> AuthorProducts { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<IssuingCompany> IssuingCompanies { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<PublishingCompany> PublishingCompanies { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<TranslatorProduct> TranslatorProducts { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}