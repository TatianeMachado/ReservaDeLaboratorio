using Microsoft.EntityFrameworkCore;

namespace ReservaDeLaboratorio.Models
{
    public class ReservaDeLaboratorioContext : DbContext
    {
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public IEnumerable<object> ProfessorTurma { get; internal set; }

        public ReservaDeLaboratorioContext(DbContextOptions<ReservaDeLaboratorioContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Reserva -> Laboratorio
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Laboratorio)
                .WithMany() // ou .WithMany(l => l.Reservas) se quiser navegação reversa
                .HasForeignKey(r => r.LaboratorioId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ Reserva -> Turma
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Turma)
                .WithMany()
                .HasForeignKey(r => r.TurmaId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ Reserva -> Professor
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Professor)
                .WithMany()
                .HasForeignKey(r => r.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}