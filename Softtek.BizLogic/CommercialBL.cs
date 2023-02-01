using Softtek.BizLogic.Core;
using Softtek.BizLogic.Inter;
using Softtek.Domain.Dto;
using Softtek.Repository;
using Softtek.Repository.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.BizLogic
{
    public class CommercialBL : BaseBL, ICommercialBL
    {
        private ICommercialRepository _CommercialRepository = null;
        public CommercialBL()
        {
            _CommercialRepository = new CommercialRepository();
        }

        public IList<SaleDto> ListarVenta()
        {
            _CommercialRepository = new CommercialRepository();
            return _CommercialRepository.ListarVenta();
        }

        public IList<SaleDto> ListarVentaXProducto(int idProducto)
        {
            _CommercialRepository = new CommercialRepository();
            return _CommercialRepository.ListarVentaXProducto(idProducto);
        }
    }
}
