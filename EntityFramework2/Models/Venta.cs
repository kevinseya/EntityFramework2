using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2.Models
{
    [Table("Ventas")]
    public partial class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Venta { get; set; }
        public int Cantidad { get; set; }

        public int? Id_Factura { get; set; }

        public int? Id_Producto { get; set; }

        [ForeignKey("Id_Factura")]
        public virtual Factura? Facturas { get; set; }

        [ForeignKey("Id_Producto")]
        public virtual Producto? Productos { get; set; }
        
    }
}
