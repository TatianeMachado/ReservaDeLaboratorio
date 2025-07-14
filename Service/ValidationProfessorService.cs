using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ReservaDeLaboratorio.Service;

public class ValidationProfessorService : IValidationProfessorService
{
    private readonly IValidationProfessorService _validationProfessorService;

    public ValidationProfessorService(IValidationProfessorService validationProfessorService)
    {
        _validationProfessorService = validationProfessorService;
    }

    public Task<bool> ValidarDadosProfessorAsync(string professorId, string nome, string email)
    {
        // Validação básica dos dados do professor
        if (string.IsNullOrWhiteSpace(professorId))
        {
            throw new ArgumentException("O ID do professor não pode ser nulo ou vazio.", nameof(professorId));
        }
        if (string.IsNullOrWhiteSpace(nome)) {
            throw new ArgumentException("O nome do professor não pode ser nulo ou vazio.", nameof(nome));
        }
        if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new ArgumentException("O e-mail do professor é inválido.", nameof(email));
        }
        return _validationProfessorService.ValidarDadosProfessorAsync(professorId, nome, email);
    }

    public Task<bool> ValidarOuLancar(string professorId, string nome, string email)
    {
        return ValidarDadosProfessorAsync(professorId, nome, email)
            .ContinueWith(task =>
            {
                if (!task.Result)
                {
                    throw new InvalidOperationException("Os dados do professor são inválidos.");
                }
                return task.Result;
            });

    }

    // Método público que valida os dados recebidos do professor



}