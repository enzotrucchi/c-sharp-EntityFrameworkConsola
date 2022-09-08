using System;
using System.Collections.Generic;

namespace EntityFrameworkConsola.Modelo
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdRubro { get; set; }

        public virtual Rubro? IdRubroNavigation { get; set; }
    }
}
