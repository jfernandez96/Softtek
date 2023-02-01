using Softtek.Domain;
using Softtek.Domain.Dto;
using Softtek.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Repository
{
    public interface ISegurityRepository: IRepository<UserDTO> 
    {
        UserDTO GetUser(UserLogins itemRequest);
    }
}
