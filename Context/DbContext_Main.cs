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
    }
}
