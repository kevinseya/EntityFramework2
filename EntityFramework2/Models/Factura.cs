using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2.Models
{
    [Table("Facturas")]
    public partial class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Factura { get; set; }

        public DateTime? Fecha { get; set; }

        [ForeignKey("Id_Cliente")]
        public int Id_Cliente { get; set; }
        [ForeignKey("Id_Cliente")]
        public virtual Cliente? Clientes { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
