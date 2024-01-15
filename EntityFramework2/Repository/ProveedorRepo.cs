using EntityFramework2.Models;
using EntityFramework2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2.Repository
{
    public class ProveedorRepo : GenericRepository<Proveedor>
    {
        public BaseEFContext context = new BaseEFContext();

        public ProveedorRepo(BaseEFContext context) : base(context)
        {
        }
    }
}
