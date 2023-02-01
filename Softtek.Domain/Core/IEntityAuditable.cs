using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Domain.Core
{
    public interface IEntityAuditable
    {
        DateTime FechaCreacion { get; set; }

        DateTime FechaModificacion { get; set; }

        string UsuarioCreacion { get; set; }

        string UsuarioModificacion { get; set; }
    }
}
