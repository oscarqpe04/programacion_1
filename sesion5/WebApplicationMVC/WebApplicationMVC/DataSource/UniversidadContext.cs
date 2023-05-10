
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.DataSource
{
    public class UniversidadContext : DbContext
    {
        public DbSet<EstudianteModel> estudianteModels { get; set; }

        protected readonly IConfiguration Configuration;
        public UniversidadContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(Configuration.GetConnectionString("MysqlConnectionContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EstudianteModel>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.nombre).IsRequired();
            });
        }
    }
}
