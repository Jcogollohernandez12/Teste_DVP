using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste_DVP.entities
{
    public class Persons
    {
        [Key]
        public int Identifier { get; set; }
        public string FirstNames { get; set; }
        public string LastNames { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string IdentificationType { get; set; }
        public DateTime CreationDate { get; set; }

        [NotMapped]
        public string? ConcatenatedIdentification { get; set; }
        [NotMapped]
        public string? ConcatenatedNamesLastNames { get; set; }
    }
}
