using ECommercePlateform.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace ECommercePlateform.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many-to-many
            //Many product with many categories.
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Products)
                .UsingEntity(j => j.ToTable("ProductCategories"));
            
            //Many-to-many
            //Many Products with many orders
            modelBuilder.Entity<Order>()
                .HasMany(p => p.Products)
                .WithMany(p => p.Orders)
                .UsingEntity(j => j.ToTable("OrderProducts"));

            //1-to-many
            //1 user with many orders
            modelBuilder.Entity<Order>()
                .HasOne(s => s.User)
                .WithMany(c => c.Orders)
                .HasForeignKey(s => s.UserId);

            //1-to-1
            //1 role to 1 user
            /*modelBuilder.Entity<User>()
                .HasOne(b => b.RoleId)
                .WithOne(i => i.User)
                .HasForeignKey<Role>(b => b.UserId);*/
        }
    }
}