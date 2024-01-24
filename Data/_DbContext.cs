using API_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace API_EF.Data;

public class _DbContext : DbContext
{
    public _DbContext(DbContextOptions<_DbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Clientes> Clientes { get; set; }
}
