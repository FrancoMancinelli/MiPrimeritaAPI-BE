using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MiPrimeritaAPI.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeritaAPI.DAL
{
    public class IESContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        protected readonly IConfiguration Configuration;

        public IESContext() {}

        public IESContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            //var connectionString = Configuration.GetConnectionString("ConexionABaseDeDatos");
            options.UseMySql("server=localhost;port=3306;database=ies;user=root;password=sasha125;", 
                ServerVersion.AutoDetect("server=localhost;port=3306;database=ies;user=root;password=sasha125;"));
        }
    }
}
