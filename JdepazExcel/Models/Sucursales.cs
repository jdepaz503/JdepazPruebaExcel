using System;
using System.Collections.Generic;

namespace JdepazExcel.Models
{
    public partial class Sucursales
    {
        public Sucursales()
        {
            MarcasEmpresa = new HashSet<MarcasEmpresa>();
        }

        public string CodigoSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<MarcasEmpresa> MarcasEmpresa { get; set; }
    }
}
