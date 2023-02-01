using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.BizLogic.Core
{
    public abstract class BaseBL
    {
        protected static readonly ILog Logger = LogManager.GetLogger(string.Empty);
    }
}
