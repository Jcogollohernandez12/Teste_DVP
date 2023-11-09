// PersonsController.cs
using Microsoft.AspNetCore.Mvc;
using Teste_DVP.Data;
using Teste_DVP.entities;

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
        [HttpPost]
        [Route("createPerson")]
        public IActionResult AddPerson(Persons person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            person.ConcatenatedIdentification = $"{person.IdentificationNumber}-{person.IdentificationType}";
            person.ConcatenatedNamesLastNames = $"{person.FirstNames} {person.LastNames}";
            return Ok(person);
        }
    }
}