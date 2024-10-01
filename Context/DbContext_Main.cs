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




            base.OnModelCreating(modelBuilder);
        }
    }
}
