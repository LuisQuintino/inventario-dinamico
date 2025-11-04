using InvDinamico.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace api_domain.Config
{
    public class BdContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Server=hopper.proxy.rlwy.net;Port=30420;Database=invdinamico;Uid=root;Pwd=yGsRLEqZFwnwtrGWnySEXusfexCKNxHO;AllowPublicKeyRetrieval=true;";
                optionsBuilder.UseMySQL(connStr);
            }
        }

        public DbSet<Operador> Operadores { get; set; }
        public DbSet<AuditTrail> AuditTrail { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }
    }
}
