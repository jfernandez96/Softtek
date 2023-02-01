using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Domain.Dto
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Perfil { get; set; }
    }
}
