using Microsoft.EntityFrameworkCore;
using Raktarkezelo.Models;
using System.Security.Cryptography.X509Certificates;

namespace Raktarkezelo.data
{
    public class RaktarDBContext : DbContext
    {
        public RaktarDBContext(DbContextOptions<RaktarDBContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<supplier> Suppliers { get; set; }

    }
}
