using Microsoft.EntityFrameworkCore;
using Zad5_Net.Models;

namespace Zad5_Net.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Product { get; set; }
    }
}
