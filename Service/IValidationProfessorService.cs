using System.Runtime.CompilerServices;

namespace ReservaDeLaboratorio.Service;

public interface IValidationProfessorService 
{


    Task<bool> ValidarDadosProfessorAsync(string professorId, string nome, string email);

    
    Task
        <bool> ValidarOuLancar(string professorId, string nome, string email);


}
