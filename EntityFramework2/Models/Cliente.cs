using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EntityFramework2.Models;

[Table("Clientes")]
public partial class Cliente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_Cliente { get; set; }

    public string? Nombres { get; set; }

    public string?  Direccion { get; set; }

    [MaxLength(10)]
    public string? Telefono { get; set; }

    [NotMapped]
    public virtual Factura Factura { get; set; }
    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}

