namespace BusinessService.DTOs
{
    public class EmpleadoResponseDto
    {
        public int IdEmpleado { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int IdPuesto { get; set; }         // <- agregado
        public string PuestoNombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaContratacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
    }
}
