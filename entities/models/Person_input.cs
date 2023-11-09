using System.ComponentModel.DataAnnotations;

namespace Teste_DVP.entities.models
{
    public class Persons_input
    {
        public string FirstNames { get; set; }
        public string LastNames { get; set; }
        public string Email { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
    }
}
