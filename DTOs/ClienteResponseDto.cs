namespace BusinessService.DTOs
{
    public class ClienteResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public string NIT { get; set; }

        public string Telefono { get; set; }
        public string Email { get; set; }
        //public string TipoCliente { get; set; }
    }
}
