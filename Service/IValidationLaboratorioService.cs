namespace ReservaDeLaboratorio.Service;

public interface IValidationLaboratorioService 
{

    Task<bool> ValidarDadosLaboratorioAsync(string laboratorioId, string nome, string descricao);

    Task<bool> ValidarOuLancar(string laboratorioId, string nome, string descricao);


}
