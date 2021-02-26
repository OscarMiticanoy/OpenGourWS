using System;
using System.Collections.Generic;

#nullable disable

namespace OpenGourWS.Modelo
{
    public partial class Producto
    {
        public Producto()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public double? Precio { get; set; }
        public int? Stock { get; set; }
        public int? FkCategoriaId { get; set; }

        public virtual Categorium FkCategoria { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
