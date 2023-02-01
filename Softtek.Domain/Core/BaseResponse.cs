using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Domain.Core
{
    public class BaseResponse
    {
        public int ErrorCode { get; set; }

        public string ErrorDescription { get; set; }
    }
}
