namespace BusinessService.DTOs
{
    public class FinalizarVisitaDto
    {
        public string Observaciones { get; set; }
        public bool Solventado { get; set; }
        public double? LatitudVisita { get; set; }
        public double? LongitudVisita { get; set; }
        public DateTime? FechaEgreso { get; set; }
    }
}
