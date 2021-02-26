using System;
using System.Collections.Generic;

#nullable disable

namespace OpenGourWS.Modelo
{
    public partial class Categorium
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
