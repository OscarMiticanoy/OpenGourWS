using System;
using System.Collections.Generic;

#nullable disable

namespace OpenGourWS.Modelo
{
    public partial class Pedido
    {
        public int PedidoId { get; set; }
        public double? Precio { get; set; }
        public int? FkClienteId { get; set; }
        public int? FkProductoId { get; set; }
        public int? Cantidad { get; set; }
        public bool? Activo { get; set; }

        public virtual Cliente FkCliente { get; set; }
        public virtual Producto FkProducto { get; set; }
    }
}
