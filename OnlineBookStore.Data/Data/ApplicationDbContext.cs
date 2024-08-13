using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Models.Models;
using System.Text.Json;


namespace OnlineBookStore.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Non-Fiction", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Science Fiction", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Fantasy", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Mystery", DisplayOrder = 5 }
            );

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Name = "John Doe",
                        UserName = "johndoe",
                        Email = "john.doe@example.com",
                        Password = "password123",
                        Address = "123 Elm Street",
                        Roles = new List<int> { 1, 2 },
                        Orders = new List<Order>()
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Jane Smith",
                        UserName = "janesmith",
                        Email = "jane.smith@example.com",
                        Password = "password456",
                        Address = "456 Oak Avenue",
                        Roles = new List<int> { 2 },
                        Orders = new List<Order>()
                    }
                );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Book One",
                    Author = "Author One",
                    Price = 9.99m,
                    PublishedDate = new DateTime(2022, 5, 1),
                    Description = "An exciting fiction book that takes you on an adventure.",
                    Genre = 2,
                    Stock=20,
                    RemainingStock=18,
                    CoverImageUrl = "https://example.com/images/bookone.jpg",
                },
                new Book
                {
                    Id = 2,
                    Title = "Book Two",
                    Author = "Author Two",
                    Price = 19.99m,
                    PublishedDate = new DateTime(2023, 1, 15),
                    Description = "A detailed non-fiction book on technology advancements.",
                    Genre = 1,
                    Stock = 30,
                    RemainingStock = 29,
                    CoverImageUrl = "https://example.com/images/booktwo.jpg",
                }
            );

            modelBuilder.Entity<Order>().HasData(
               new Order
               {
                   Id = 1,
                   UserId = 1,
                   OrderDate = DateTime.UtcNow,
                   TotalAmount = 19.98m
               },
               new Order
               {
                   Id = 2,
                   UserId = 2,
                   OrderDate = DateTime.UtcNow,
                   TotalAmount = 19.99m
               }
           );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    BookId = 1,
                    Quantity = 2,
                    PriceAtPurchase = 9.99m
                },
                new OrderItem
                {
                    Id = 2,
                    OrderId = 2,
                    BookId = 2,
                    Quantity = 1,
                    PriceAtPurchase = 19.99m
                }
            );

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.Genre);
        }
    }
}
