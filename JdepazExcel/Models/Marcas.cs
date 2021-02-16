using System;
using System.Collections.Generic;

namespace JdepazExcel.Models
{
    public partial class Marcas
    {
        public Marcas()
        {
            MarcasEmpresa = new HashSet<MarcasEmpresa>();
        }

        public string CodigoMarca { get; set; }
        public string NombreMarca { get; set; }
        public string Logo { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<MarcasEmpresa> MarcasEmpresa { get; set; }
    }
}
