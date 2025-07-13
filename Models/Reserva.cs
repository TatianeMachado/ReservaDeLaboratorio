using System.ComponentModel.DataAnnotations;

namespace ReservaDeLaboratorio.Models;

public class Reserva
{
    [Key]
    public int ReservaId { get; set; }

    [Required]
    public int ProfessorId { get; set; }
    public Professor Professor { get; set; } = new();

    [Required]
    public int TurmaId { get; set; }
    public Turma Turma { get; set; } = new();

    [Required]
    public int LaboratorioId { get; set; }
    public Laboratorio Laboratorio { get; set; } = new();

    [Required]
    public DateTime Data { get; set; }

    [Required]
    public TimeSpan HoraInicio { get; set; }

    [Required]
    public int DuracaoEmMinutos { get; set; } = 50; // reserva padrão
}
