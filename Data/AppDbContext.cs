using ChamdosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChamdosAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}

    public DbSet<Chamado> Chamados { get; set; }
}
