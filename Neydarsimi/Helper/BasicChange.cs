using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neydarsimi.Helper
{
    public enum Basic
    {
        New_tulkur,
        update_tulkur,
        update_neydarsimi
    }

    public class BasicChange
    {
        public Basic basicData { get; set; }
    }
}
