using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Catering.Data
{

    // The Context handles the entity framework database

    public class CateringDbContext : DbContext
    {
        public DbSet<FoodItem> FoodItem { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<MenuFoodItem> MenuFoodItem { get; set; }

        public DbSet<FoodBooking> FoodBooking { get; set; }

        // Set Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Catering;");

        // when the database model is created run this function
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Set key relationships

            // Composite key
            builder.Entity<MenuFoodItem>()
                .HasKey(a => new { a.MenuId, a.FoodItemId });

            // Foreign key
            builder.Entity<MenuFoodItem>()
                .HasOne(a => a.Menu)
                .WithMany(m => m.MenuFoodItems)
                .HasForeignKey(a => a.MenuId);

            // Foreign key
            builder.Entity<MenuFoodItem>()
                .HasOne(a => a.FoodItem)
                .WithMany()
                .HasForeignKey(a => a.FoodItemId);

            // Fill the database with sample data upon creation
            builder.Entity<FoodItem>().HasData(
                new FoodItem { FoodItemId = 1, Description = "Veggie Burger", UnitPrice = 8.99f },
                new FoodItem { FoodItemId = 2, Description = "Chicken Burger", UnitPrice = 6.99f },
                new FoodItem { FoodItemId = 3, Description = "Cheese Burger", UnitPrice = 5.99f },
                new FoodItem { FoodItemId = 4, Description = "Fettucini Alfredo", UnitPrice = 10.99f },
                new FoodItem { FoodItemId = 5, Description = "Cheese Toastie", UnitPrice = 2.99f },
                new FoodItem { FoodItemId = 6, Description = "Trifle", UnitPrice = 3.99f },
                new FoodItem { FoodItemId = 7, Description = "Banoffee Pudding", UnitPrice = 3.99f }
            );

            builder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, MenuName = "Burgers"},
                new Menu { MenuId = 2, MenuName = "Vegetarian"},
                new Menu { MenuId = 3, MenuName = "Dessert"}
            );

            builder.Entity<MenuFoodItem>().HasData(
                new MenuFoodItem {MenuId = 1, FoodItemId = 1},
                new MenuFoodItem {MenuId = 1, FoodItemId = 2},
                new MenuFoodItem {MenuId = 1, FoodItemId = 3},
                new MenuFoodItem {MenuId = 2, FoodItemId = 1},
                new MenuFoodItem {MenuId = 2, FoodItemId = 4},
                new MenuFoodItem {MenuId = 2, FoodItemId = 7},
                new MenuFoodItem {MenuId = 3, FoodItemId = 6},
                new MenuFoodItem {MenuId = 3, FoodItemId = 7}
            );

            builder.Entity<FoodBooking>().HasData(
                new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1, NumberOfGuests = 5, MenuId = 1},
                new FoodBooking { FoodBookingId = 2, ClientReferenceId = 2, NumberOfGuests = 2, MenuId = 2}
            );
        }
    }
}
