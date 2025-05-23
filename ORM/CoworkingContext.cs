using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.ORM
{
    public partial class CoworkingContext : DbContext
    {
        public CoworkingContext() { }

        public CoworkingContext(DbContextOptions<CoworkingContext> options)
            : base(options) { }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<TipoSala> TiposSala { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<ReservaDetalhada> ViewReservasDetalhadas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telefone).HasMaxLength(20);
            });

            modelBuilder.Entity<TipoSala>(entity =>
            {
                entity.ToTable("TipoSala");
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Capacidade);
                entity.Property(e => e.PrecoHora).HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Sala");
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100); // ✅ Alinhado com o banco

                entity.HasOne(e => e.TipoSala)
                      .WithMany(t => t.Salas)
                      .HasForeignKey(e => e.TipoSalaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("Reserva");
                entity.Property(e => e.DataReserva).HasColumnType("date");
                entity.Property(e => e.HoraInicio).HasColumnType("time");
                entity.Property(e => e.HoraFim).HasColumnType("time");
                entity.Property(e => e.Observacoes).HasMaxLength(255);
                //entity.Property(e => e.Valor).HasColumnType("decimal(10,2)");

                entity.HasOne(e => e.Cliente)
                      .WithMany(c => c.Reservas)
                      .HasForeignKey(e => e.ClienteId);

                entity.HasOne(e => e.Sala)
                      .WithMany(s => s.Reservas)
                      .HasForeignKey(e => e.SalaId);
            });

            modelBuilder.Entity<ReservaDetalhada>(entity =>
            {
                entity.HasNoKey().ToView("View_ReservasDetalhadas");
                entity.Property(e => e.Cliente).HasMaxLength(100);
                entity.Property(e => e.Sala).HasMaxLength(50);
                entity.Property(e => e.TipoSala).HasMaxLength(50);
                entity.Property(e => e.Observacoes).HasMaxLength(255);
                entity.Property(e => e.PrecoHora).HasColumnType("decimal(10,2)");
               // entity.Property(e => e.Valor).HasColumnType("decimal(10,2)");
                entity.Property(e => e.DataReserva).HasColumnType("date");
                entity.Property(e => e.HoraInicio).HasColumnType("time");
                entity.Property(e => e.HoraFim).HasColumnType("time");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
