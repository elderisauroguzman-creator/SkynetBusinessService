using BusinessService.DTOs;
using System.Linq;
using BusinessService.Interfaces;
using BusinessService.Models;
using Microsoft.EntityFrameworkCore;
using Skynet.BusinessService.Data;
using System.Threading.Tasks;

namespace BusinessService.Services
{
    public class ClienteService : IClienteService
    {
        private readonly BusinessDbContext _context;

        public ClienteService(BusinessDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetAllAsync()
        {
            return await _context.Clientes
                //.Include(c => c.TipoCliente)
                .Select(c => new ClienteResponseDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Direccion = c.Direccion,
                    Latitud = c.Latitud,
                    Longitud = c.Longitud,
                    NIT = c.NIT,
                    Telefono = c.Telefono,
                    Email = c.Email,
                    //TipoCliente = c.TipoCliente.Nombre
                })
                .ToListAsync();
        }

        public async Task<ClienteResponseDto> GetByIdAsync(int id)
        {
            var cliente = await _context.Clientes
                //.Include(c => c.TipoCliente)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null) return null;

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                Latitud = cliente.Latitud,
                Longitud = cliente.Longitud,
                NIT = cliente.NIT,
                //TipoCliente = cliente.TipoCliente.Nombre
            };
        }

        public async Task<ClienteResponseDto> CreateAsync(ClienteRequestDto request)
        {
            var cliente = new Cliente
            {
                Nombre = request.Nombre,
                Direccion = request.Direccion,
                Latitud = request.Latitud,
                Longitud = request.Longitud,
                NIT = request.NIT,
                //IdTipoCliente = request.IdTipoCliente,
                Telefono = request.Telefono,
                Email = request.Email,
                FechaCreacion = DateTime.Now,
                Activo = true
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            //var tipo = await _context.TiposClientes.FindAsync(request.IdTipoCliente);

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                Latitud = cliente.Latitud,
                Longitud = cliente.Longitud,
                NIT = cliente.NIT,
                //TipoCliente = tipo?.Nombre ?? "N/A"
            };
        }
    }
}
