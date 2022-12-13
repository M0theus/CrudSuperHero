using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) {}
    
    public DbSet<SuperHero> SuperHeroes { get; set; }
}