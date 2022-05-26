using Microsoft.AspNetCore.Mvc;
using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.CORE.DTO;

namespace MiPrimeritaAPI.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserBL userBL { get; set; }

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginDTO l)
        {
            if(userBL.Loguear(l))
            {
                return Ok();
            } 
            else
            {
                return BadRequest();

            }
        }

        [HttpPost("Registration")]
        public ActionResult Registration(UserDTO u)
        {
            if (userBL.Registrar(u))
            {
                return Ok();
            }
            else
            {
                return BadRequest();

            }
        }
    }
}
