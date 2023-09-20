using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Data.Contexts
{
    public class OrganicAppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public OrganicAppDbContext(DbContextOptions<OrganicAppDbContext> options) : base(options)
        {

        }
        public DbSet<Advert>? Adverts { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductDetail>? ProductDetails { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<BlogDetail>? BlogDetails { get; set; }
        public DbSet<Owner>? Owners { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Basket>? Baskets { get; set; }
        public DbSet<Favorite>? Favorites { get; set; }
        public DbSet<Setting>? Settings { get; set; }
        public DbSet<Social>? Socials { get; set; }
        public DbSet<Subscribe>? subscribes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasOne(x => x.ProductDetails).WithOne(x => x.Product).HasForeignKey<ProductDetail>(x => x.ProductId);
            builder.Entity<Product>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.Entity<Comment>().HasOne(x => x.Product).WithMany(x => x.Comments).HasForeignKey(x => x.ProductId);
            builder.Entity<Blog>().HasOne(x => x.BlogDetails).WithOne(x => x.Blog).HasForeignKey<BlogDetail>(x => x.BlogId);
            builder.Entity<Blog>().HasOne(x => x.Owner).WithMany(x => x.Blogs).HasForeignKey(x => x.OwnerId);
            builder.Entity<Basket>().HasOne(x => x.AppUser).WithMany(x => x.Baskets).HasForeignKey(x => x.AppUserId);
            builder.Entity<Favorite>().HasOne(x => x.AppUser).WithMany(x => x.Favorites).HasForeignKey(x => x.AppUserId);

            base.OnModelCreating(builder);
        }

    }
}
