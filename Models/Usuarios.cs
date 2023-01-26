using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    [Table("usuarios")]
    public class Usuarios
    {
        [Key]
        public int id { get; set; }
        public string name_ { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string cpf { get; set; }
    }
}
