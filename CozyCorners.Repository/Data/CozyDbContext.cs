using CozyCorners.Core.Models;
using CozyCorners.Core.Models.Identity;
using CozyCorners.Core.Models.Order;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Repository.Data
{
   public class CozyDbContext:IdentityDbContext<AppUser>
    {
        public CozyDbContext(DbContextOptions<CozyDbContext> optionsBuilder):base(optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          //  builder.Entity<Category>()
          //.HasMany(c => c.SubCategories)
          //.WithOne(c => c.ParentCategory)
          //.HasForeignKey(c => c.ParentCategoryId);

            builder.Entity<Favorite>()
                .HasKey(e => new { e.ProductId, e.UserId });
           
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


		}


		public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        //public DbSet<ProductPhoto> ProductPhotos { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
