namespace BusinessService.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int IdPuesto { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaContratacion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;

        public Puesto Puesto { get; set; }
        public ICollection<VisitaTecnica> Visitas { get; set; }
    }
}
