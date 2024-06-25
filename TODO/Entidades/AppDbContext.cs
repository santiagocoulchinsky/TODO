using Microsoft.EntityFrameworkCore;

namespace TODO.Entidades
{
    class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Cambio de ruta de creación de la DB del proyecto
            var rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            var rutaProyecto = Path.GetFullPath(Path.Combine(rutaBase, @"..\..\..\"));
            var rutaBd = Path.Combine(rutaProyecto, "sqlite.db");

            optionsBuilder.UseSqlite($"Data Source={rutaBd}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asigna>()
                .HasKey(x => new { x.TareaId, x.OperarioId });

            modelBuilder.Entity<Asigna>()
                .HasOne(x => x.Tarea)
                .WithMany(h => h.Operarios)
                .HasForeignKey(x => x.TareaId);

            modelBuilder.Entity<Asigna>()
                .HasOne(x=> x.Operario)
                .WithMany(l=> l.Tareas)     
                .HasForeignKey(x=>x.OperarioId);

            base.OnModelCreating(modelBuilder);     
        
        }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Operario> Operarios { get; set; }
        public DbSet<Asigna> Asignaciones { get; set; }
    }
}
