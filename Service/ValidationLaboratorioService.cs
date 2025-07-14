namespace ReservaDeLaboratorio.Service;

public class ValidationLaboratorioService : IValidationLaboratorioService
{
    private readonly IValidationLaboratorioService _validationLaboratorioService;
    public ValidationLaboratorioService(IValidationLaboratorioService validationLaboratorioService)
    {
        _validationLaboratorioService = validationLaboratorioService;
    }
    public Task<bool> ValidarDadosLaboratorioAsync(string laboratorioId, string nome, string descricao)
    {
        // Verificações básicas
        if (string.IsNullOrWhiteSpace(laboratorioId))
            return Task.FromResult(false);
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do laboratório não pode ser nulo ou vazio.", nameof(nome));
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("A descrição do laboratório não pode ser nula ou vazia.", nameof(descricao));
        // Chamando serviço de validação adicional
        return _validationLaboratorioService.ValidarDadosLaboratorioAsync(laboratorioId, nome, descricao);
    }
    public Task<bool> ValidarOuLancar(string laboratorioId, string nome, string descricao)
    {
        return ValidarDadosLaboratorioAsync(laboratorioId, nome, descricao)
            .ContinueWith(task =>
            {
                if (!task.Result)
                    throw new InvalidOperationException("Os dados do laboratório são inválidos.");
                return task.Result;
            });
    }
}
