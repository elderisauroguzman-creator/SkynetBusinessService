using BusinessService.DTOs;

namespace BusinessService.Interfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoResponseDto>> GetAllAsync();
        Task<EmpleadoResponseDto?> GetByIdAsync(int id);
        Task<EmpleadoResponseDto> CreateAsync(EmpleadoRequestDto dto);
        Task<EmpleadoResponseDto?> UpdateAsync(int id, EmpleadoRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
