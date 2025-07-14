namespace ReservaDeLaboratorio.Service;

public interface IValidationTurmaService
{
    Task<bool> ValidarDadosTurmaAsync(string turmaId, string nome, string cursoId);
    Task<bool> ValidarOuLancar(string turmaId, string nome, string cursoId);
}
