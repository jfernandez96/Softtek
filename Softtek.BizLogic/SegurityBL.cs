using Softtek.Repository.SqlServer;
using Softtek.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.BizLogic.Core;
using Softtek.BizLogic.Inter;
using Softtek.Domain.Dto;
using Softtek.Domain;

namespace Softtek.BizLogic
{
    public class SegurityBL:BaseBL, ISegurityBL
    {
        private ISegurityRepository _segurityRepository = null;
        public SegurityBL()
        {
            _segurityRepository = new SegurityRepository();
        }

        public UserDTO GetUser(UserLogins itemRequest)
        {
            _segurityRepository = new SegurityRepository();
            return _segurityRepository.GetUser(itemRequest);
        }
    }
}
