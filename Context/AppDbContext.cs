using Microsoft.EntityFrameworkCore;
using ReservaDeLaboratorio.Models;

namespace ReservaDeLaboratorio.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Professor> Professores { get; set; }
    public DbSet<Turma> Turmas { get; set; }
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    public bool PodeEstenderReserva(DateTime data, TimeSpan fimAula, int laboratorioId)
    {
        var existeReservaPosterior = Reservas.Any(r =>
            r.LaboratorioId == laboratorioId &&
            r.Data == data &&
            r.HoraInicio < fimAula.Add(TimeSpan.FromMinutes(50)) &&
            r.HoraInicio >= fimAula);

        return !existeReservaPosterior;
    }
}
