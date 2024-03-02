using Microsoft.EntityFrameworkCore;
using Modelos.Modelos;

namespace Negocio.Context
{
    public partial class GestionDatabaseContext : DbContext
    {
        public GestionDatabaseContext()
        {
        }

        public GestionDatabaseContext(DbContextOptions<GestionDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beneficio> Beneficios { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<EvaluacionDesempeno> EvaluacionDesempenos { get; set; } = null!;
        public virtual DbSet<HistorialPago> HistorialPagos { get; set; } = null!;
        public virtual DbSet<Nomina> Nominas { get; set; } = null!;
        public virtual DbSet<TareasProyecto> TareasProyectos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=odiseo\\ODISEO;Database=GestionDatabase;User Id=odiseo;Password=padomo153;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beneficio>(entity =>
            {
                entity.Property(e => e.BeneficioId)
                    .ValueGeneratedNever()
                    .HasColumnName("BeneficioID").HasColumnType("uniqueidentifier");

                entity.Property(e => e.Cobertura).HasMaxLength(100);

                entity.Property(e => e.Costos).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Beneficios)
                    .HasForeignKey(d => d.EmpleadoId)
                    .HasConstraintName("FK__Beneficio__Emple__31EC6D26");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.DepartamentoId)
                    .ValueGeneratedNever()
                    .HasColumnName("DepartamentoID").HasColumnType("uniqueidentifier"); ;

                entity.Property(e => e.NombreDepartamento).HasMaxLength(50);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.EmpleadoId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmpleadoID").HasColumnType("uniqueidentifier"); ;

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.CorreoElectronico).HasMaxLength(100);

                entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.FechaContratacion).HasColumnType("date");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Genero).HasMaxLength(10);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(20);

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("FK__Empleados__Depar__267ABA7A");
            });

            modelBuilder.Entity<EvaluacionDesempeno>(entity =>
            {
                entity.HasKey(e => e.EvaluacionId)
                    .HasName("PK__Evaluaci__99ABA8A56223E901");

                entity.ToTable("EvaluacionDesempeno");

                entity.Property(e => e.EvaluacionId)
                    .ValueGeneratedNever()
                    .HasColumnName("EvaluacionID").HasColumnType("uniqueidentifier"); ;

                entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");

                entity.Property(e => e.FechaEvaluacion).HasColumnType("date");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.EvaluacionDesempenos)
                    .HasForeignKey(d => d.EmpleadoId)
                    .HasConstraintName("FK__Evaluacio__Emple__34C8D9D1");
            });

            modelBuilder.Entity<HistorialPago>(entity =>
            {
                entity.Property(e => e.HistorialPagoId)
                    .ValueGeneratedNever()
                    .HasColumnName("HistorialPagoID").HasColumnType("uniqueidentifier"); ;

                entity.Property(e => e.FechaPago).HasColumnType("date");

                entity.Property(e => e.NominaId).HasColumnName("NominaID");

                entity.HasOne(d => d.Nomina)
                    .WithMany(p => p.HistorialPagos)
                    .HasForeignKey(d => d.NominaId)
                    .HasConstraintName("FK__Historial__Nomin__2F10007B");
            });

            modelBuilder.Entity<Nomina>(entity =>
            {
                entity.ToTable("Nomina");

                entity.Property(e => e.NominaId)
                    .ValueGeneratedNever()
                    .HasColumnName("NominaID")
                     .HasColumnType("uniqueidentifier");

                entity.Property(e => e.Bonificaciones).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CalculosSalariales).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Deducciones).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");

                entity.Property(e => e.FechaGeneracion).HasColumnType("date");

                entity.Property(e => e.PeriodoPago).HasMaxLength(20);

                entity.Property(e => e.TotalPagar).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Nominas)
                    .HasForeignKey(d => d.EmpleadoId)
                    .HasConstraintName("FK__Nomina__Empleado__2C3393D0");
            });

            modelBuilder.Entity<TareasProyecto>(entity =>
            {
                entity.HasKey(e => e.TareaId)
                    .HasName("PK__TareasPr__5CD83671F2FBBFA2");

                entity.Property(e => e.TareaId)
                    .ValueGeneratedNever()
                    .HasColumnName("TareaID").HasColumnType("uniqueidentifier"); ;

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");

                entity.Property(e => e.Estado).HasMaxLength(20);

                entity.Property(e => e.FechaAsignacion).HasColumnType("date");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.TareasProyectos)
                    .HasForeignKey(d => d.EmpleadoId)
                    .HasConstraintName("FK__TareasPro__Emple__29572725");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("UsuarioID").HasColumnType("uniqueidentifier"); ;

                entity.Property(e => e.ClaveAcceso).HasMaxLength(50);

                entity.Property(e => e.NombreUsuario).HasMaxLength(50);

                entity.Property(e => e.Rol)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
