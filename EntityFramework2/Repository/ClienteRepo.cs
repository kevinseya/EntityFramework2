using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework2.Repository
{
    public class ClienteRepo : GenericRepository<Cliente>
    {
        public BaseEFContext context = new BaseEFContext();

        public ClienteRepo(BaseEFContext context) : base(context)
        {
        }
    }
}
