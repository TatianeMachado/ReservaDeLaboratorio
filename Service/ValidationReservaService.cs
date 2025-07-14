
namespace ReservaDeLaboratorio.Service;

public class ValidationReservaService : IValidationReservaService
{
    private readonly IValidationReservaService _validationReservaService;
    public ValidationReservaService(IValidationReservaService validationReservaService)
    {
        _validationReservaService = validationReservaService;
    }
    public Task<bool> ValidarDadosReservaAsync(string reservaId, string laboratorioId, string professorId, string turmaId, DateTime dataHoraInicio, DateTime dataHoraFim)
    {
        // Verificações básicas
        if (string.IsNullOrWhiteSpace(reservaId))
            return Task.FromResult(false);
        if (string.IsNullOrWhiteSpace(laboratorioId))
            throw new ArgumentException("O ID do laboratório não pode ser nulo ou vazio.", nameof(laboratorioId));
        if (string.IsNullOrWhiteSpace(professorId))
            throw new ArgumentException("O ID do professor não pode ser nulo ou vazio.", nameof(professorId));
        if (string.IsNullOrWhiteSpace(turmaId))
            throw new ArgumentException("O ID da turma não pode ser nulo ou vazio.", nameof(turmaId));
        if (dataHoraInicio >= dataHoraFim)
            throw new ArgumentException("A data e hora de início deve ser anterior à data e hora de fim.", nameof(dataHoraInicio));
        // Chamando serviço de validação adicional
        return _validationReservaService.ValidarDadosReservaAsync(reservaId, laboratorioId, professorId, turmaId, dataHoraInicio, dataHoraFim);
    }
    public Task<bool> ValidarOuLancar(string reservaId, string laboratorioId, string professorId, string turmaId, DateTime dataHoraInicio, DateTime dataHoraFim)
    {
        return ValidarDadosReservaAsync(reservaId, laboratorioId, professorId, turmaId, dataHoraInicio, dataHoraFim)
            .ContinueWith(task =>
            {
                if (!task.Result)
                    throw new InvalidOperationException("Os dados da reserva são inválidos.");

                return task.Result;
                
            });
    }
}
   

