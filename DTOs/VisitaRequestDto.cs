namespace BusinessService.DTOs
{
    public class VisitaRequestDto
    {
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaVisita { get; set; }
        public string Incidencia { get; set; }
        public int Prioridad { get; set; } = 3;
        public decimal? CostoServicio { get; set; }
    }
}
