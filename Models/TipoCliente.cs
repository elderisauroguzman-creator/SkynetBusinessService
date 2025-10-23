﻿namespace BusinessService.Models
{
    public class TipoCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;

       // public ICollection<Cliente> Clientes { get; set; }
    }
}
