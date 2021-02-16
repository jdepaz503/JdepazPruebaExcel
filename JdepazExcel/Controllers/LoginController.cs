using AutoMapper;
using JdepazExcel.DTO;
using JdepazExcel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JdepazExcel.Controllers
{
    public class LoginController : Controller
    {
        private readonly Autos_ExcelContext db;
        private readonly IMapper map;
        private readonly IConfiguration config;

        public LoginController(Autos_ExcelContext _db, IMapper mapper, IConfiguration configuration)
        {
            db = _db ?? throw new ArgumentNullException(nameof(_db));
            map = mapper ?? throw new ArgumentNullException(nameof(mapper));
            config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            var paramUserName = new SqlParameter("@username", request.User);
            var paramPassword = new SqlParameter("@pass_user", request.Password);
            var paramPatron = new SqlParameter("@Patron", "V4Kc10ne$");

            try
            {
                IList<Usuarios> usr = db.Usuarios.FromSqlRaw("SP_ValidarUsuario @username, @pass_user, @Patron", paramUserName, paramPassword, paramPatron).ToList();
                if (usr != null && usr.Count == 1)
                {
                    response = map.Map<LoginResponse>(usr.FirstOrDefault());
                    if (response.Estado == false)
                    {
                        return RedirectToAction("desactivado", "Login");
                    }
                    else
                    {
                        var user = response.NombreUser;
                        return RedirectToAction("Index", "MarcasEmpresas");
                    }
                        
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
                    
                
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
