using EntityFramework2.Models;
using EntityFramework2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2.Repository
{
    public class CategoriaRepo : GenericRepository<Categoria>
    {
        public BaseEFContext context = new BaseEFContext();

        public CategoriaRepo(BaseEFContext context) : base(context)
        {
        }
    }
}
