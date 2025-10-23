namespace BusinessService.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public double? Longitud { get; set; }
        public double? Latitud { get; set; }
        public string NIT { get; set; } = string.Empty;
      //  public int IdTipoCliente { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;

       // public TipoCliente TipoCliente { get; set; }
        public ICollection<VisitaTecnica> Visitas { get; set; }
    }
}
