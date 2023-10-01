using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaIngresoBibliotecario.Dominio;
using PruebaIngresoBibliotecario.Dominio.Prestamos;

namespace PruebaIngresoBibliotecario.Datos
{
    public class BibliotecaContext : DbContext
    {

        private readonly IConfiguration Config;

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options, IConfiguration config) : base(options)
        {
            Config = config;
        }

        public DbSet<PrestamoLibro> PrestamoLibros { get; set; } = default!;

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
