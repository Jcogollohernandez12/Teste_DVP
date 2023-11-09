// PersonsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Teste_DVP.Data;
using Teste_DVP.entities;
using Teste_DVP.entities.models;

namespace Teste_DVP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPersons()
        {

            try {

                var persons = _context.Persons.ToList();
                var mappedPersons = persons.Select(person => new
                {
                    person.Identifier,
                    person.FirstNames,
                    person.LastNames,
                    person.IdentificationNumber,
                    person.Email,
                    person.IdentificationType,
                    person.CreationDate,
                    ConcatenatedIdentification = $"{person.IdentificationNumber}-{person.IdentificationType}",
                    ConcatenatedNamesLastNames = $"{person.FirstNames} {person.LastNames}"
                }).ToList();

                return Ok(mappedPersons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new{ Message = "Error en el servidor",Error = ex.Message});
            }
            
        }
        [HttpPost]
        [Route("createPerson")]
        public IActionResult AddPerson(Persons_input person_input)
        {
            try {

                var random = new Random();
                var randomIdentifier = random.Next(1, 1000000);
                var person = new Persons
                {
                    Identifier = randomIdentifier,
                    FirstNames = person_input.FirstNames,
                    LastNames = person_input.LastNames,
                    IdentificationNumber = person_input.IdentificationNumber,
                    Email = person_input.Email,
                    IdentificationType = person_input.IdentificationType,
                    CreationDate = DateTime.Now,
                };
                _context.Persons.Add(person);
                _context.SaveChanges();
                person.ConcatenatedIdentification = $"{person.IdentificationNumber}-{person.IdentificationType}";
                person.ConcatenatedNamesLastNames = $"{person.FirstNames} {person.LastNames}";
                return Ok(person);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error en el servidor", Error = ex.Message });
            }
            
        }
    }
}