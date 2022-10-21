using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class BookStoreOnlineDbContext : DbContext
    {
        public BookStoreOnlineDbContext()
            : base("name=BookStoreOnlineDbContext")
        {
        }

        public virtual DbSet<Actions> Actions { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Covers> Covers { get; set; }
        public virtual DbSet<CoverTranslations> CoverTranslations { get; set; }
        public virtual DbSet<Functions> Functions { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<ImportDetails> ImportDetails { get; set; }
        public virtual DbSet<Imports> Imports { get; set; }
        public virtual DbSet<IssuingCompanies> IssuingCompanies { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Originals> Originals { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Prices> Prices { get; set; }
        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<ProductCategoryTranslations> ProductCategoryTranslations { get; set; }
        public virtual DbSet<ProductPromotions> ProductPromotions { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductTranslations> ProductTranslations { get; set; }
        public virtual DbSet<Promotions> Promotions { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }
        public virtual DbSet<ProviderTranslations> ProviderTranslations { get; set; }
        public virtual DbSet<PublishingCompanies> PublishingCompanies { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Shippings> Shippings { get; set; }
        public virtual DbSet<Translators> Translators { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actions>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Actions)
                .HasForeignKey(e => e.ActionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Authors>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Authors)
                .Map(m => m.ToTable("AuthorProducts").MapLeftKey("AuthorID").MapRightKey("ProductID"));

            modelBuilder.Entity<Brands>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Brands)
                .HasForeignKey(e => e.BrandID);

            modelBuilder.Entity<Carts>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Carts>()
                .Property(e => e.PromotionMoney)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Covers>()
                .HasMany(e => e.CoverTranslations)
                .WithRequired(e => e.Covers)
                .HasForeignKey(e => e.CoverID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Covers>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Covers)
                .HasForeignKey(e => e.CoverID);

            modelBuilder.Entity<CoverTranslations>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Functions>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Functions)
                .HasForeignKey(e => e.FunctionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Images>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Images)
                .Map(m => m.ToTable("ProductImages").MapLeftKey("ImageID").MapRightKey("ProductID"));

            modelBuilder.Entity<ImportDetails>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Imports>()
                .HasMany(e => e.ImportDetails)
                .WithRequired(e => e.Imports)
                .HasForeignKey(e => e.ImportID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IssuingCompanies>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.IssuingCompanies)
                .HasForeignKey(e => e.IssuingCompanyID);

            modelBuilder.Entity<Languages>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Languages>()
                .HasMany(e => e.CoverTranslations)
                .WithRequired(e => e.Languages)
                .HasForeignKey(e => e.LanguageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Languages>()
                .HasMany(e => e.ProductCategoryTranslations)
                .WithRequired(e => e.Languages)
                .HasForeignKey(e => e.LanguageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Languages>()
                .HasMany(e => e.ProductTranslations)
                .WithRequired(e => e.Languages)
                .HasForeignKey(e => e.LanguageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Languages>()
                .HasMany(e => e.ProviderTranslations)
                .WithRequired(e => e.Languages)
                .HasForeignKey(e => e.LanguageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetails>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Orders>()
                .Property(e => e.CustomerPhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.PromotionMoney)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Orders)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.Shippings)
                .WithRequired(e => e.Orders)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Originals>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Originals)
                .HasForeignKey(e => e.OriginID);

            modelBuilder.Entity<Prices>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Prices>()
                .HasOptional(e => e.Products)
                .WithRequired(e => e.Prices);

            modelBuilder.Entity<ProductCategories>()
                .HasMany(e => e.ProductCategoryTranslations)
                .WithRequired(e => e.ProductCategories)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategories>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategories)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<ProductCategories>()
                .HasMany(e => e.Promotions)
                .WithOptional(e => e.ProductCategories)
                .HasForeignKey(e => e.ProductCategoryID);

            modelBuilder.Entity<ProductCategories>()
                .HasMany(e => e.Promotions1)
                .WithMany(e => e.ProductCategories1)
                .Map(m => m.ToTable("ProductCategoryPromotions").MapLeftKey("ProductCategoryID").MapRightKey("PromotionID"));

            modelBuilder.Entity<ProductCategoryTranslations>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategoryTranslations>()
                .Property(e => e.SeoAlias)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.SeoAlias)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Carts)
                .WithOptional(e => e.Products)
                .HasForeignKey(e => e.ProductID);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.ImportDetails)
                .WithRequired(e => e.Products)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.ImportDetails1)
                .WithRequired(e => e.Products1)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Products)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.ProductTranslations)
                .WithRequired(e => e.Products)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Promotions)
                .WithOptional(e => e.Products)
                .HasForeignKey(e => e.ProductID);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Translators)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("TranslatorProducts").MapLeftKey("ProductID").MapRightKey("TranslatorID"));

            modelBuilder.Entity<ProductTranslations>()
                .Property(e => e.SeoDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ProductTranslations>()
                .Property(e => e.SeoTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ProductTranslations>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Promotions>()
                .Property(e => e.DiscountAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Promotions>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Promotions>()
                .HasMany(e => e.Carts)
                .WithOptional(e => e.Promotions)
                .HasForeignKey(e => e.PromotionID);

            modelBuilder.Entity<Promotions>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Promotions)
                .HasForeignKey(e => e.PromotionID);

            modelBuilder.Entity<Promotions>()
                .HasMany(e => e.ProductPromotions)
                .WithRequired(e => e.Promotions)
                .HasForeignKey(e => e.PromotionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Providers>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Providers>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Providers>()
                .HasMany(e => e.Imports)
                .WithRequired(e => e.Providers)
                .HasForeignKey(e => e.ProviderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Providers>()
                .HasMany(e => e.ProviderTranslations)
                .WithRequired(e => e.Providers)
                .HasForeignKey(e => e.ProviderCompanyID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProviderTranslations>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<PublishingCompanies>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.PublishingCompanies)
                .HasForeignKey(e => e.PublishingCompanyID);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.RoleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRoles").MapLeftKey("RoleID").MapRightKey("UserID"));

            modelBuilder.Entity<Users>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Shippings)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserID);
        }
    }
}
