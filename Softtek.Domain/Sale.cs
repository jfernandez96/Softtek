using Softtek.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Domain
{
    public class Sale: BaseResponse
    {
        public int IdProducto { get; set; }
        public string NombreAsesor  { get; set; }
        public string ApellidosAsesor { get; set; }
        public string producto { get; set; }
        public int Cantidad { get; set; }
    }
}
