using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Common
{
    public class Enumeradores
    {
        #region ControlWeb
        public enum ResponseCode
        {
            CorrectCode = 0,
            ErrorCodeControlled = 1,
            ErrorCodeDataBase = 2,
            ErrorCodeApplication = 3
        }
        #endregion
    }
}
