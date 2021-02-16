using System;
using System.Collections.Generic;

namespace JdepazExcel.Models
{
    public partial class Empresas
    {
        public Empresas()
        {
            MarcasEmpresa = new HashSet<MarcasEmpresa>();
        }

        public string CodigoEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<MarcasEmpresa> MarcasEmpresa { get; set; }
    }
}
