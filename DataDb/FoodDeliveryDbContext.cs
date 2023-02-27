using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.DataDb
{
    public class FoodDeliveryDbContext : DbContext
    {
        public FoodDeliveryDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>()
                .HasOne(f => f.MenuItemCategory)
                .WithMany(fc => fc.MenuItem)
                .HasForeignKey(f => f.MenuItemCategoryId);

            modelBuilder.Entity<MenuItemCategory>().HasData(
                new MenuItemCategory
                {
                    Id = 1,
                    Name = "Drinks"
                },
                new MenuItemCategory
                {
                    Id = 2,
                    Name = "MainDish"
                });
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Coca Cola",
                    Price = 599,
                    MenuItemCategoryId = 1,
                    RestaurantId = 1
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Lemonade",
                    Price = 399,
                    MenuItemCategoryId = 1,
                    RestaurantId = 1
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Beer",
                    Price = 999,
                    MenuItemCategoryId = 1,
                    RestaurantId = 1
                },
                new MenuItem
                {
                    Id = 4,
                    Name = "Big Burguer",
                    Price = 3999,
                    MenuItemCategoryId = 2,
                    RestaurantId = 1
                },
                new MenuItem
                {
                    Id = 5,
                    Name = "Chicken Burguer",
                    Price = 3599,
                    MenuItemCategoryId = 2,
                    RestaurantId = 1
                });
            modelBuilder.Entity<Driver>().HasData(
                new Driver
                {
                    Id = 1,
                    FirstName = "Lewis",
                    LastName = "Hamilton"
                });
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Hungry",
                    LastName = "John"
                });
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    UnitNumber = 500,
                    AddressLine1 = "some customer address",
                    City = "Some City",
                    Region = "Some Region",
                    PostalCode = 11530040
                },
                new Address
                {
                    Id = 2,
                    UnitNumber = 1200,
                    AddressLine1 = "some restaurant address",
                    City = "Some City",
                    Region = "Some Region",
                    PostalCode = 18150010
                });
            modelBuilder.Entity<CustomerAddress>().HasData(
                new CustomerAddress
                {
                    Id = 1,
                    CustomerId = 1,
                    AddressId = 1,
                });
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus
                {
                    Id = 1,
                    Status = "Processing"
                },
                new OrderStatus
                {
                    Id = 2,
                    Status = "Out to deliver"
                },
                new OrderStatus
                {
                    Id = 3,
                    Status = "Canceled"
                },
                new OrderStatus
                {
                    Id = 4,
                    Status = "Returned"
                });
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = 1,
                    Name = "Fake restaurant place",
                    AddressId = 2
                });

        }

        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<MenuItemCategory> MenuItemCategory { get; set; }
        public DbSet<FoodOrder> FoodOrder { get; set; }
        public DbSet<OrderMenuItem> OrderMenuItem { get; set; }
    }
}
