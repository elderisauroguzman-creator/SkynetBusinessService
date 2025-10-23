using BusinessService.DTOs;

namespace BusinessService.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardResponseDto> GetDashboardSupervisorAsync(int supervisorId);
        Task<IEnumerable<VisitaResponseDto>> GetVisitasHoyTecnicoAsync(int tecnicoId);
    }
}
