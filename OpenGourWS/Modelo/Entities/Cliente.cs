using System;
using System.Collections.Generic;

#nullable disable

namespace OpenGourWS.Modelo
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
