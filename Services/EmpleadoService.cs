using BusinessService.DTOs;
using BusinessService.Interfaces;
using BusinessService.Models;
using Microsoft.EntityFrameworkCore;
using Skynet.BusinessService.Data;

namespace BusinessService.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly BusinessDbContext _context;

        public EmpleadoService(BusinessDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpleadoResponseDto>> GetAllAsync()
        {
            var empleados = await _context.Empleados
                .Include(e => e.Puesto)
                .ToListAsync();

            return empleados.Select(e => new EmpleadoResponseDto
            {
                IdEmpleado = e.IdEmpleado,
                Codigo = e.Codigo,
                Nombre = e.Nombre,
                IdPuesto = e.IdPuesto,                  // <- agregado
                PuestoNombre = e.Puesto?.Nombre ?? string.Empty,
                Telefono = e.Telefono,
                Email = e.Email,
                FechaContratacion = e.FechaContratacion,
                FechaCreacion = e.FechaCreacion,
                Activo = e.Activo
            });
        }

        public async Task<EmpleadoResponseDto?> GetByIdAsync(int id)
        {
            var e = await _context.Empleados
                .Include(e => e.Puesto)
                .FirstOrDefaultAsync(x => x.IdEmpleado == id);

            if (e == null) return null;

            return new EmpleadoResponseDto
            {
                IdEmpleado = e.IdEmpleado,
                Codigo = e.Codigo,
                Nombre = e.Nombre,
                PuestoNombre = e.Puesto?.Nombre ?? string.Empty,
                Telefono = e.Telefono,
                Email = e.Email,
                FechaContratacion = e.FechaContratacion,
                FechaCreacion = e.FechaCreacion,
                Activo = e.Activo
            };
        }

        public async Task<EmpleadoResponseDto> CreateAsync(EmpleadoRequestDto dto)
        {
            var empleado = new Empleado
            {
                Codigo = dto.Codigo,
                Nombre = dto.Nombre,
                IdPuesto = dto.IdPuesto,
                Telefono = dto.Telefono,
                Email = dto.Email,
                FechaContratacion = dto.FechaContratacion,
                Activo = dto.Activo,
                FechaCreacion = DateTime.Now
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(empleado.IdEmpleado) ?? new EmpleadoResponseDto();
        }

        public async Task<EmpleadoResponseDto?> UpdateAsync(int id, EmpleadoRequestDto dto)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return null;

            empleado.Codigo = dto.Codigo;
            empleado.Nombre = dto.Nombre;
            empleado.IdPuesto = dto.IdPuesto;
            empleado.Telefono = dto.Telefono;
            empleado.Email = dto.Email;
            empleado.FechaContratacion = dto.FechaContratacion;
            empleado.Activo = dto.Activo;

            await _context.SaveChangesAsync();

            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

