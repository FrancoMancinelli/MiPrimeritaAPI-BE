using AutoMapper;
using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.CORE.DTO;
using MiPrimeritaAPI.DAL.Contracts;
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.BL.Implementations
{
    public class UserBL : IUserBL
    {
        public IUserDAL userDAL { get; set; }
        public IMapper mapper { get; set; }

        public UserBL(IUserDAL userDAL, IMapper mapper)
        {
            this.userDAL = userDAL;
            this.mapper = mapper;
        }

        public bool Loguear(LoginDTO loginDTO)
        {
            var usuario = userDAL.GetUser(loginDTO.Username, loginDTO.Password);
            if(usuario != null) 
            { 
                return true; 
            } else
            {
                return false;
            }
        }

        public bool Registrar(UserDTO userDTO)
        {
            var usuario = userDAL.GetUser(userDTO.Email, userDTO.Password);
            if (usuario == null)
            {
                usuario = mapper.Map<User>(userDTO);
                userDAL.Registrar(usuario);
                return true;
            }
            return false;
        }
    }
}
