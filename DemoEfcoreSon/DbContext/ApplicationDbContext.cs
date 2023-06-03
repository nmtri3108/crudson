using DemoEfcoreSon.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEfcoreSon.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Shop> Shops { get; set; }
}