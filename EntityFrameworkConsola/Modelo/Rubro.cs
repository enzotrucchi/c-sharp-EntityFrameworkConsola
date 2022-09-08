using System;
using System.Collections.Generic;

namespace EntityFrameworkConsola.Modelo
{
    public partial class Rubro
    {
        public Rubro()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
