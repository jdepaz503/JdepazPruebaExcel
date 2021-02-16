using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JdepazExcel.DTO
{
    public class LoginRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string User { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
