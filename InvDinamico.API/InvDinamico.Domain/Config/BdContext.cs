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
                var connStr = "Database=invdinamico;Port=3306;Data Source=127.0.0.1;User Id=root;SslMode=none;";
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
