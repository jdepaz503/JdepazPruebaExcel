using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JdepazExcel.Models
{

    public class LoginViewModel
    {
            [Required(ErrorMessage = "Correo es requerido")]
            [StringLength(50, MinimumLength = 6, ErrorMessage = "Favor especificar correo")]
            public string User { get; set; }

            [Required(ErrorMessage = "Clave es requerida")]
            [DataType(DataType.Password)]
            [StringLength(20, MinimumLength = 6, ErrorMessage = "Favor especificar Clave")]
            public string Password { get; set; }
    }
}
