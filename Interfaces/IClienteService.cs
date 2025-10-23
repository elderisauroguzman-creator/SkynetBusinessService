using BusinessService.DTOs;

namespace BusinessService.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponseDto>> GetAllAsync();
        Task<ClienteResponseDto> GetByIdAsync(int id);
        Task<ClienteResponseDto> CreateAsync(ClienteRequestDto request);
    }
}
