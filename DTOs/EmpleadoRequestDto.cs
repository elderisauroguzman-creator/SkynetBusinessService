namespace BusinessService.DTOs
{
    public class EmpleadoRequestDto
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int IdPuesto { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaContratacion { get; set; }
        public bool Activo { get; set; } = true;
    }
}
