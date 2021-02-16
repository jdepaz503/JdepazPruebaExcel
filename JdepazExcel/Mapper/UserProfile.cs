using AutoMapper;
using JdepazExcel.DTO;
using JdepazExcel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JdepazExcel.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Usuarios, LoginResponse>();
        }
    }
}
