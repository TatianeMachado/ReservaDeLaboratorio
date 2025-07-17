using Microsoft.AspNetCore.Mvc.Filters;

namespace ReservaDeLaboratorio.Filters;

public class ApiLogginFilter : IActionFilter
{

    private readonly ILogger<ApiLogginFilter> _logger;
    public ApiLogginFilter(ILogger<ApiLogginFilter> logger)
    {
        _logger = logger;

    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Logica antes da execucao do metodo
        _logger.LogInformation("### Executando -> OnActionExecuting");
        _logger.LogInformation("#####################################");
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        _logger.LogInformation("#####################################");
        _logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
        _logger.LogInformation("#####################################");


    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Logica depois da execucao do metodo
        _logger.LogInformation("### Executando -> OnActionExecuted");
        _logger.LogInformation("#####################################");
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        _logger.LogInformation($"Status Code: {context.HttpContext.Response.StatusCode}");
        _logger.LogInformation("#####################################");

    }
}