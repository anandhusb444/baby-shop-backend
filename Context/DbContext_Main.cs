using baby_shop_backend.Models;
using baby_shop_backend.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace baby_shop_backend.Context
{
    public class DbContext_Main : DbContext
    {
        public DbSet<User> User { get; set; }
        
        public DbContext_Main(DbContextOptions options) : base(options)
        {   
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            modelBuilder.Entity<User>().HasData(new User { id = 3, userName = "Admin", userEmail = "admin@.com",password = BCrypt.Net.BCrypt.HashPassword("A12345678",salt),Role = "Admin",isStatus = true});


            modelBuilder.Entity<User>()
                .HasOne(c => c.cart)
                .WithOne(u => u.User)
                .HasForeignKey<Cart>(f => f.UserId);

            modelBuilder.Entity<CartItems>()
                .HasOne(c => c.product)
                .WithMany(ci => ci.cartItems)
                .HasForeignKey(f => f.productId);

            modelBuilder.Entity<Products>()
                .HasOne(c => c.category)
                .WithMany(p => p.products);

            modelBuilder.Entity<Order>()
                .HasOne(u => u.User)
                .WithMany(o => o.order)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<OrderItems>()
                .HasOne(o => o.order)
                .WithMany(o => o.orderItems)
                .HasForeignKey(f => f.orderId);

            modelBuilder.Entity<OrderItems>()
                .HasOne(p => p.products)
                .WithMany(o => o.orderitems)
                .HasForeignKey(f => f.productId);

            modelBuilder.Entity<Order>()
                .Property(o => o.total)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItems>()
                .Property(o => o.price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<WhishList>()
                .HasOne(u => u.User)
                .WithMany(w => w.whishLists)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<WhishList>()
                .HasOne(p => p.Products)
                .WithMany(w => w.whishlist)
                .HasForeignKey(f => f.productId);

            modelBuilder.Entity<Products>()
                .Property(p => p.price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Category>()
                .HasData(new Category { id = 1, CategoriesName = "All" }, new Category { id = 2, CategoriesName = "Toys" }, new Category { id = 3, CategoriesName = "Foods" }, new Category { id = 4, CategoriesName = "Clothing" });


            base.OnModelCreating(modelBuilder);
        }
    }
}
