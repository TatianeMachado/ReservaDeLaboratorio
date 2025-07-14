namespace ReservaDeLaboratorio.Service;

public interface IValidationReservaService
{
    Task<bool> ValidarDadosReservaAsync(string reservaId, string laboratorioId, string professorId, string turmaId, DateTime dataHoraInicio, DateTime dataHoraFim);
    Task<bool> ValidarOuLancar(string reservaId, string laboratorioId, string professorId, string turmaId, DateTime dataHoraInicio, DateTime dataHoraFim);
}
