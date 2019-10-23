using Microsoft.EntityFrameworkCore;
using PetStore.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Db
{
	public class PetStoreContext : DbContext
	{
		public DbSet<User> User { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderItem> OrderItem { get; set; }
		public DbSet<Product> Product { get; set; }

		public PetStoreContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasKey(o => o.Id);

			modelBuilder.Entity<Order>()
				.HasKey(o => o.Id);

			modelBuilder.Entity<OrderItem>()
				.HasKey(o => new { o.OrderId, o.ProductId });

			modelBuilder.Entity<Product>()
				.HasKey(o => o.Id);
		}
	}
}
