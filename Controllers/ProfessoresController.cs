using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using ReservaDeLaboratorio.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReservaDeLaboratorio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessoresController : ControllerBase
{
    private readonly ILogger<ProfessoresController> _logger;
    private readonly ReservaDeLaboratorioContext _context;
    public ProfessoresController(ILogger<ProfessoresController> logger, ReservaDeLaboratorioContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("ProfPorTuma")]
    public IActionResult GetProf() {
        {
            var profTurmas = _context.Professores.Include(profTurmas => profTurmas.Turmas)
                .Select(profTurmas => new
                {
                    ProfessorId = profTurmas.ProfessorId,
                    Nome = profTurmas.Nome,
                    TurmaCount = profTurmas.Turmas.Count()
                }).ToList();
            if (profTurmas == null || !profTurmas.Any()) 
            {
                _logger.LogWarning("Nenhum professor encontrado com suas turmas");
                return NotFound("Nenhum professor encontrado com suas turmas");
            }
            return Ok(profTurmas);


        }
        
    }
    [HttpGet("ProfPorTuma/{id}")]
    public IActionResult GetProfPorTurma(int id)
    {
        var profTurmas = _context.Professores.Include(profTurmas => profTurmas.Turmas)
            .Where(profTurmas => profTurmas.Turmas.Any(t => t.TurmaId == id))
            .Select(profTurmas => new
            {
                ProfessorId = profTurmas.ProfessorId,
                Nome = profTurmas.Nome,
                TurmaCount = profTurmas.Turmas.Count()
            }).ToList();
        if (profTurmas == null || !profTurmas.Any())
        {
            _logger.LogWarning($"Nenhum professor encontrado para a turma com ID {id}");
            return NotFound($"Nenhum professor encontrado para a turma com ID {id}");
        }
        return Ok(profTurmas);
    }
    [HttpGet]
        public IActionResult Get()
        {
            var professores = _context.Professores.ToList();
            _logger.LogInformation("Obtendo lista de professores");

            if (professores == null || !professores.Any())
            {
                _logger.LogWarning("Nenhum professor encontrado");
                return NotFound("Nenhum professor encontrado");
            }
            return Ok(professores);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"Obtendo professor com ID {id}");
            var professor = _context.Professores.FirstOrDefault(p => p.ProfessorId == id);
            if (professor == null)
            {
                _logger.LogWarning($"Professor com ID {id} não encontrado");
                return NotFound($"Professor com ID {id} não encontrado");
            }
            return Ok(professor);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)

        {
            if (professor is null || string.IsNullOrEmpty(""))
            {
                _logger.LogError("Professor não pode ser nulo");
                return BadRequest("Professor não pode ser nulo");
            }
            _context.Professores.Add(professor);
            _context.SaveChanges();
            _logger.LogInformation($"Professor {professor.Nome} adicionado com sucesso");
            return CreatedAtAction(nameof(Get), new { id = professor.ProfessorId }, professor);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Professor professor)
        {
            if (professor == null || professor.ProfessorId != id)
            {
                _logger.LogError("Dados inválidos para atualização do professor");
                return BadRequest("Dados inválidos para atualização do professor");
            }


            _context.Entry(professor).State = EntityState.Modified;
            _context.SaveChanges();
            _logger.LogInformation($"Professor com ID {id} atualizado com sucesso");
            return Ok(professor);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"Removendo professor com ID {id}");
            var professor = _context.Professores.FirstOrDefault(p => p.ProfessorId == id);
            if (professor == null)
            {
                _logger.LogWarning($"Professor com ID {id} não encontrado");
                return NotFound($"Professor com ID {id} não encontrado");
            }
            _context.Professores.Remove(professor);
            _context.SaveChanges();
            _logger.LogInformation($"Professor com ID {id} removido com sucesso");
            return Ok(professor);
        }
    }
