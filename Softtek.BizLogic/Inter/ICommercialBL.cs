using Softtek.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.BizLogic.Inter
{
    public interface ICommercialBL
    {
        IList<SaleDto> ListarVenta();
        IList<SaleDto> ListarVentaXProducto(int idProducto);
    }
}
