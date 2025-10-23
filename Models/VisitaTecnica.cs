namespace BusinessService.Models
{
    public class VisitaTecnica
    {
        public int IdVisita { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaVisita { get; set; }
        public DateTime FechaReporte { get; set; } = DateTime.Now;
        public string Incidencia { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public bool Solventado { get; set; } = false;
        public double? LatitudVisita { get; set; }
        public double? LongitudVisita { get; set; }
        public DateTime? FechaSolucion { get; set; }
        public int Prioridad { get; set; } = 3;
        public decimal? CostoServicio { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
    }
}
