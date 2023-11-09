using System.ComponentModel.DataAnnotations;

namespace Teste_DVP.entities
{
    public class Users
    {
        [Key]
        public int Identifier { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
