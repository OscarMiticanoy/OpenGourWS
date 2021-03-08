using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenGourWS.Modelo.Helper
{
    public class PedidoResponse
    {
        public int pedido_Id { get; set; }
        public double total { get; set; }
        public String cliente { get; set; }
        public String producto { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public int activo { get; set; }

    }
}
