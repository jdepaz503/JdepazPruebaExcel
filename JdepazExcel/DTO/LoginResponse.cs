using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JdepazExcel.DTO
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string NombreUser { get; set; }
        public string Username { get; set; }
        public string EmailUser { get; set; }
        public byte[] PassUser { get; set; }
        public int TelefonoUser { get; set; }
        public DateTime FnacUser { get; set; }
        public bool Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
