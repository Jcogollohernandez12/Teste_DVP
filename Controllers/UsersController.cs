using Microsoft.AspNetCore.Mvc;
using Teste_DVP.Data;
using Teste_DVP.entities;
using Teste_DVP.entities.models;

namespace Teste_DVP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var usersList = _context.Users.ToList();
                return Ok(usersList);
            } catch (Exception ex){
                return StatusCode(500, new { Message = "Error en el servidor", Error = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("createUser")]
        public IActionResult AddUser(User_input user_input){
            try{

                if (user_input is null){
                throw new ArgumentNullException(nameof(user_input));
                }

            var usersList = _context.Users.ToList();

            var user = _context.Users.FirstOrDefault(u => u.Username == user_input.Username && u.Password == user_input.Password);
            if (user == null) {
                var random = new Random();
                var randomIdentifier = random.Next(1, 1000000);
                var user_add = new Users {
                    Identifier = randomIdentifier,
                    Username = user_input.Username,
                    Password = user_input.Password,
                    CreationDate = DateTime.Now,

                };
                _context.Users.Add(user_add);
                _context.SaveChanges();
                return Ok(new { Message = "usuario creado con exito", User = user_add });
            }
            else
            {
                return Ok(new { Message = "Exite un usuario registrado, Inicie sesion", User = (object)null });
            }
            } catch (Exception ex){
                return StatusCode(500, new { Message = "Error en el servidor", Error = ex.Message });
            }
        }
    }
}