namespace BusinessService.DTOs
{
    public class ClienteRequestDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public string NIT { get; set; }
      //  public int IdTipoCliente { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
