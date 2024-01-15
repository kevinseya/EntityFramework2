using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EntityFramework2.Models
{
    [Table("Categorias")]
    public partial class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Categoria { get; set; }

        public string? Descripcion { get; set; }
        [NotMapped]
        public virtual Producto Producto { get; set; }
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    }
}
