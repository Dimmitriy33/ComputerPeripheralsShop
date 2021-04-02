using System.Data.Entity;

namespace ComputerPeripheralsShop.DB
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DbConnectionString")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
