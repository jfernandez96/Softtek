using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Domain.Core
{
    public abstract class EntityAuditable : Entity, IEntityAuditable
    {
        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public string? UsuarioCreacion { get; set; }

        public string? UsuarioModificacion { get; set; }
    }
}
