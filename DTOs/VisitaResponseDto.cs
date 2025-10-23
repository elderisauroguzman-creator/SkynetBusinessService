namespace BusinessService.DTOs
{
    public class VisitaResponseDto
    {
        public int IdVisita { get; set; }
        public string Cliente { get; set; }
        public string Empleado { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Incidencia { get; set; }
        public bool Solventado { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public double? LatitudVisita { get; set; }
        public double? LongitudVisita { get; set; }
    }
}
