using System;
using System.Collections.Generic;

namespace JdepazExcel.Models
{
    public partial class MarcasEmpresa
    {
        public int Id { get; set; }
        public string CodigoMarca { get; set; }
        public string CodigoEmpresa { get; set; }
        public string CodigoSucursal { get; set; }
        public string Detalles { get; set; }

        public virtual Empresas CodigoEmpresaNavigation { get; set; }
        public virtual Marcas CodigoMarcaNavigation { get; set; }
        public virtual Sucursales CodigoSucursalNavigation { get; set; }
    }
}
