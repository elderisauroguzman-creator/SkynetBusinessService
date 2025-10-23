using BusinessService.DTOs;
using BusinessService.Interfaces;
using BusinessService.Models;
using Microsoft.EntityFrameworkCore;
using Skynet.BusinessService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.Services
{
    public class VisitaService : IVisitaService
    {
        private readonly BusinessDbContext _context;

        public VisitaService(BusinessDbContext context)
        {
            _context = context;
        }

        // Planificar nueva visita
        public async Task<VisitaResponseDto> PlanificarVisitaAsync(VisitaRequestDto request)
        {
            var visita = new VisitaTecnica
            {
                IdCliente = request.IdCliente,
                IdEmpleado = request.IdEmpleado,
                FechaVisita = request.FechaVisita,
                Incidencia = request.Incidencia,
                Prioridad = request.Prioridad,
                CostoServicio = request.CostoServicio
            };

            _context.VisitasTecnicas.Add(visita);
            await _context.SaveChangesAsync();

            var cliente = await _context.Clientes.FindAsync(request.IdCliente);
            var empleado = await _context.Empleados.FindAsync(request.IdEmpleado);

            return new VisitaResponseDto
            {
                IdVisita = visita.IdVisita,
                Cliente = cliente?.Nombre,
                Empleado = empleado?.Nombre,
                FechaVisita = visita.FechaVisita,
                Incidencia = visita.Incidencia,
                Solventado = visita.Solventado,
                // Opcional si quieres guardar lat/lng de egreso
            };
        }

        // Finalizar / registrar egreso de la visita
        public async Task<bool> FinalizarVisitaAsync(int idVisita, FinalizarVisitaDto dto)
        {
            var visita = await _context.VisitasTecnicas.FindAsync(idVisita);
            if (visita == null) return false;

            visita.Observaciones = dto.Observaciones;
            visita.Solventado = dto.Solventado;
            visita.FechaSolucion = dto.FechaEgreso ?? DateTime.Now;

            // Guardar coordenadas del egreso
            visita.LatitudVisita = dto.LatitudVisita;
            visita.LongitudVisita = dto.LongitudVisita;

            _context.VisitasTecnicas.Update(visita);
            await _context.SaveChangesAsync();
            return true;
        }
        // Obtener todas las visitas (ignora idEmpleado)
        public async Task<IEnumerable<VisitaResponseDto>> GetTodasVisitasAsync(DateTime? fecha = null)
        {
            var query = _context.VisitasTecnicas
                .Include(v => v.Cliente)
                .Include(v => v.Empleado)
                .AsQueryable();

            if (fecha.HasValue)
                query = query.Where(v => v.FechaVisita.Date == fecha.Value.Date);

            return await query
                .Select(v => new VisitaResponseDto
                {
                    IdVisita = v.IdVisita,
                    Cliente = v.Cliente != null ? v.Cliente.Nombre: "(sin cliente)",
                    Empleado = v.Empleado != null ? v.Empleado.Nombre : "(sin empleado)",
                    FechaVisita = v.FechaVisita,
                    Incidencia = v.Incidencia,
                    Solventado = v.Solventado,
                    Latitud = v.Cliente != null ? v.Cliente.Latitud : (double?)null,
                    Longitud = v.Cliente != null ? v.Cliente.Longitud : (double?)null,
                    LatitudVisita = v.LatitudVisita,
                    LongitudVisita = v.LongitudVisita
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<VisitaResponseDto>> GetVisitasByEmpleadoAsync(int empleadoId, DateTime? fecha = null)
        {
            var query = _context.VisitasTecnicas
                .Include(v => v.Cliente)
                .Include(v => v.Empleado)
                .Where(v => v.IdEmpleado == empleadoId);

            return await query
                .Select(v => new VisitaResponseDto
                {
                    IdVisita = v.IdVisita,
                    Cliente = v.Cliente != null ? v.Cliente.Nombre : "(sin cliente)",
                    Empleado = v.Empleado != null ? v.Empleado.Nombre : "(sin empleado)",
                    FechaVisita = v.FechaVisita,
                    Incidencia = v.Incidencia,
                    Solventado = v.Solventado,
                })
                .ToListAsync();
        }
    }
}