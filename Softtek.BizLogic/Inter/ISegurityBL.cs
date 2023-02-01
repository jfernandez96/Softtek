using Softtek.Domain.Dto;
using Softtek.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.BizLogic.Inter
{
    public interface ISegurityBL
    {
        UserDTO GetUser(UserLogins itemRequest);
    }
}
