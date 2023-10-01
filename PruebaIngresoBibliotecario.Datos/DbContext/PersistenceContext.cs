using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaIngresoBibliotecario.Dominio;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Datos
{
    public class PersistenceContext : DbContext
    {

        private readonly IConfiguration Config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            Config = config;
        }

        public DbSet<PrestamoLibro> PrestamoLibros { get; set; }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema(Config.GetValue<string>("SchemaName"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
