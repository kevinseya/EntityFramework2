using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2.Models
{
    [Table("Productos")]
    public partial class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Producto { get; set; }
        public string Descripcion { get; set; }
        public decimal? precio { get; set; }
        public int? Id_Proveedor { get; set; }
        public int? Id_Categoria { get; set; }

        [ForeignKey("Id_Proveedor")]
        public virtual Proveedor? Proveedores { get; set; }

        [ForeignKey("Id_Categoria")]
        public virtual Categoria? Categorias { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
