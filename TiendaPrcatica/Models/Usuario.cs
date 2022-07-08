using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaPrcatica.Models
{

    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public string Username { get; set; }


        public string Nombre { get; set; }
        public string Password { get; set; }

    }
}
