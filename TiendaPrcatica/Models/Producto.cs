using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaPrcatica.Models
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }

        [Column("priceUnit")]
        public decimal Price { get; set; }

        [Column("fechaProd")]
        public DateTime DateProd { get; set; }

        [Column("fechaVenc")]
        public DateTime DateVenc { get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
