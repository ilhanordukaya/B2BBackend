using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context.EntityFramework
{
	
	public class SimpleContextDb : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		optionsBuilder.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=B2BProject;Pooling=false;");
			
		}

		 

		public DbSet<User> Users { get; set; }
		public DbSet<OperationClaim> OperationClaims { get; set; }
		public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
		public DbSet<EmailParameter> EmailParameters { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<CustomerRealationship> CustomerRealationships { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PriceListDetail> PriceListDetails { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
	}
}
