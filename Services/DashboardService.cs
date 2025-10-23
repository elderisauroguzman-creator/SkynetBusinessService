using BusinessService.DTOs;
using BusinessService.Interfaces;
using Microsoft.EntityFrameworkCore;
using Skynet.BusinessService.Data;

namespace BusinessService.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly BusinessDbContext _context;

        public DashboardService(BusinessDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardResponseDto> GetDashboardSupervisorAsync(int supervisorId)
        {
            // (Ejemplo: todos los empleados bajo un supervisor tendrían que estar relacionados a un rol "Supervisor")
            var visitas = await _context.VisitasTecnicas
                .Include(v => v.Cliente)
                .Include(v => v.Empleado)
                .ToListAsync();

            return new DashboardResponseDto
            {
                TotalVisitas = visitas.Count,
                Pendientes = visitas.Count(v => !v.Solventado),
                Solventadas = visitas.Count(v => v.Solventado),
                ProximasVisitas = visitas
                    .Where(v => v.FechaVisita >= DateTime.Today)
                    .Take(5)
                    .Select(v => new VisitaResponseDto
                    {
                        IdVisita = v.IdVisita,
                        Cliente = v.Cliente.Nombre,
                        Empleado = v.Empleado.Nombre,
                        FechaVisita = v.FechaVisita,
                        Incidencia = v.Incidencia,
                        Solventado = v.Solventado
                    })
            };
        }

        public async Task<IEnumerable<VisitaResponseDto>> GetVisitasHoyTecnicoAsync(int tecnicoId)
        {
            return await _context.VisitasTecnicas
                .Include(v => v.Cliente)
                .Where(v => v.IdEmpleado == tecnicoId)
                .Select(v => new VisitaResponseDto
                {
                    IdVisita = v.IdVisita,
                    Cliente = v.Cliente.Nombre,
                    Empleado = v.Empleado.Nombre,
                    FechaVisita = v.FechaVisita,
                    Incidencia = v.Incidencia,
                    Solventado = v.Solventado
                })
                .ToListAsync();
        }
    }
}
