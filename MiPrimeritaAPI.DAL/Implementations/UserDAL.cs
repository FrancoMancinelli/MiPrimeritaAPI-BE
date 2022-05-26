using MiPrimeritaAPI.DAL.Contracts;
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.DAL.Implementations
{
    public class UserDAL : IUserDAL
    {
        public IESContext Context { get; set; }

        public UserDAL(IESContext Context)
        {
            this.Context = Context;
        }

        public void Registrar(User u)
        {
            if (u != null)
            {
                Context.Usuarios.Add(u);
                Context.SaveChanges();
            }
        }

        public bool Login(string email, string password)
        {
            var usuario = GetUser(email, password);
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User? GetUser(string email, string password)
        {
            return Context.Usuarios.FirstOrDefault(a => a.Email == email && a.Password == password);

        }
    }
}
