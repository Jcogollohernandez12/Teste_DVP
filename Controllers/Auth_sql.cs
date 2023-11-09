using Microsoft.AspNetCore.Mvc;
using Teste_DVP.Data;
using Teste_DVP.entities.models;

namespace Teste_DVP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(Credential_input credential)
        {

            try {

                if (credential is null)
                {
                    throw new ArgumentNullException(nameof(credential));
                }

                var usersList = _context.Users.ToList();

                var user = _context.Users.FirstOrDefault(u => u.Username == credential.Username && u.Password == credential.Password);
                if (user != null)
                {
                    return Ok(new { Message = "Inicio de sesión exitoso", User = user });
                }
                else
                {
                    return Ok(new { Message = "usuario o contraseña incorrecto", User = (object)null });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error en el servidor", Error = ex.Message });
            }
            

        }

    }
}