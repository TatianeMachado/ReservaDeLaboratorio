using System.ComponentModel.DataAnnotations;

namespace ReservaDeLaboratorio.Models;

public class Laboratorio
{
    [Key]
    public int LaboratorioId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public int Capacidade { get; set; } = 20; // padrão definido

    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
