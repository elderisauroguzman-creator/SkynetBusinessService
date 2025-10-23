namespace BusinessService.DTOs
{
    public class DashboardResponseDto
    {
        public int TotalVisitas { get; set; }
        public int Pendientes { get; set; }
        public int Solventadas { get; set; }
        public IEnumerable<VisitaResponseDto> ProximasVisitas { get; set; }
    }
}
