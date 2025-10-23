using BusinessService.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessService.Interfaces
{
    public interface IVisitaService
    {
        // Planificar nueva visita
        Task<VisitaResponseDto> PlanificarVisitaAsync(VisitaRequestDto request);

        // Finalizar / egresar visita
        Task<bool> FinalizarVisitaAsync(int idVisita, FinalizarVisitaDto dto);

        // Obtener todas las visitas (ignora idEmpleado)
        Task<IEnumerable<VisitaResponseDto>> GetTodasVisitasAsync(DateTime? fecha = null);
        Task<IEnumerable<VisitaResponseDto>> GetVisitasByEmpleadoAsync(int empleadoId, DateTime? fecha = null);
    }

}
