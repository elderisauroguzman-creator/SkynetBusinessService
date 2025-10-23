using BusinessService.DTOs;
using BusinessService.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VisitasController : ControllerBase
{
    private readonly IVisitaService _visitaService;

    public VisitasController(IVisitaService visitaService)
    {
        _visitaService = visitaService;
    }

    // Endpoint para planificar una nueva visita
    [HttpPost("planificar")]
    public async Task<IActionResult> Planificar([FromBody] VisitaRequestDto dto)
    {
        var result = await _visitaService.PlanificarVisitaAsync(dto);
        return Ok(result);
    }

    // Endpoint para finalizar/egresar una visita
    [HttpPost("finalizar/{idVisita}")]
    public async Task<IActionResult> Finalizar(int idVisita, [FromBody] FinalizarVisitaDto dto)
    {
        var result = await _visitaService.FinalizarVisitaAsync(idVisita, dto);
        return result ? Ok(new { mensaje = "Visita finalizada" }) : NotFound();
    }


    // Endpoint para obtener visitas
    // Ahora devuelve todas las visitas, ignorando idEmpleado
    [HttpGet]
    public async Task<IActionResult> GetTodasVisitas()
    {
        var result = await _visitaService.GetTodasVisitasAsync();
        if (result == null || !result.Any())
            return NotFound(new { mensaje = "No hay visitas" });
        return Ok(result);
    }
}
