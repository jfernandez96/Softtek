using Softtek.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Repository.SqlServer.Core
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
    }
}
