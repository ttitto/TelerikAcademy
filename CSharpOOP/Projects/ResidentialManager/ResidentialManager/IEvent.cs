using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    public interface IEvent
    {
        DateTime Time { get; set; }
    }
}
