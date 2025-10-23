using BusinessService.DTOs;
using BusinessService.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("supervisor/{idSupervisor}")]
    public async Task<IActionResult> GetDashboardSupervisor(int idSupervisor)
    {
        return Ok(await _dashboardService.GetDashboardSupervisorAsync(idSupervisor));
    }

    [HttpGet("tecnico/{idTecnico}")]
    public async Task<IActionResult> GetVisitasHoyTecnico(int idTecnico)
    {
        return Ok(await _dashboardService.GetVisitasHoyTecnicoAsync(idTecnico));
    }
}