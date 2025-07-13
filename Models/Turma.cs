using System.ComponentModel.DataAnnotations;

namespace ReservaDeLaboratorio.Models;

public class Turma
{
    [Key]
    public int TurmaId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public int QuantidadeAlunos { get; set; }

    [Required]
    public int ProfessorId { get; set; }
    public Professor Professor { get; set; } = new();

    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
