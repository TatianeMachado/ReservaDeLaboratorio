namespace ReservaDeLaboratorio.Service;

public class ValidationTurmaService : IValidationTurmaService
{
    

    private readonly IValidationTurmaService _validationTurmaService;

    public ValidationTurmaService(IValidationTurmaService validationTurmaService)
    {
        _validationTurmaService = validationTurmaService;
    }

    public Task<bool> ValidarDadosTurmaAsync(string turmaId, string nome, string cursoId)
    {
        // Verificações básicas
        if (string.IsNullOrWhiteSpace(turmaId))
            return Task.FromResult(false);

        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome da turma não pode ser nulo ou vazio.", nameof(nome));

        if (string.IsNullOrWhiteSpace(cursoId))
            throw new ArgumentException("O ID do curso não pode ser nulo ou vazio.", nameof(cursoId));

        // Chamando serviço de validação adicional
        return _validationTurmaService.ValidarDadosTurmaAsync(turmaId, nome, cursoId);
    }

    public Task<bool> ValidarOuLancar(string turmaId, string nome, string cursoId)
    {
        return ValidarDadosTurmaAsync(turmaId, nome, cursoId)
            .ContinueWith(task =>
            {
                if (!task.Result)
                    throw new InvalidOperationException("Os dados da turma são inválidos.");

                return task.Result;
            });
    }
}

