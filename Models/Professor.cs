using System.ComponentModel.DataAnnotations;

namespace ReservaDeLaboratorio.Models;

public class Professor
{
    [Key]
    public int ProfessorId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
