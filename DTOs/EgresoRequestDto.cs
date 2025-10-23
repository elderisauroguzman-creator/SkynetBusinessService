namespace BusinessService.DTOs
{
    public class EgresoRequestDto
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime FechaEgreso { get; set; }
        public string? Observaciones { get; set; } // opcional
        public bool Solventado { get; set; }
    }
}