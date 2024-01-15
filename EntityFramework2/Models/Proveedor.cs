using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2.Models
{
    [Table("Proveedores")]
    public partial class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Proveedor{ get; set; }

        public string? Nombre { get; set; }

        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
        [NotMapped]
        public virtual Producto Producto { get; set; }

    }
}
