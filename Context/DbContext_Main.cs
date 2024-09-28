using Microsoft.EntityFrameworkCore;

namespace baby_shop_backend.Context
{
    public class DbContext_Main : DbContext
    {
        public DbContext_Main(DbContextOptions options) : base(options)
        {   
            
        }
    }
}
