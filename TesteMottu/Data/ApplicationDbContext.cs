namespace TesteMottu.Data;

using Microsoft.EntityFrameworkCore;
using TesteMottu.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Moto> Motos { get; set; }
    public DbSet<Entregador> Entregadores { get; set; }
    public DbSet<Locacao> Locacoes { get; set; }
}
