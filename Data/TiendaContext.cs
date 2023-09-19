using Microsoft.EntityFrameworkCore;
using MVC_ComponenteCodeFirst.Models;

namespace MVC_ComponenteCodeFirst.Data
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }

        public DbSet<Componente> Componentes => Set<Componente>();
        public DbSet<Ordenador> Ordenadores => Set<Ordenador>();

        public DbSet<Pedido> Pedidos => Set<Pedido>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Componente>()
                .Property(x => x.OrdenadorId).IsRequired(false);
            modelBuilder.Entity<Ordenador>()
                .Property(x=>x.PedidoId).IsRequired(false);
        }

    }
}
