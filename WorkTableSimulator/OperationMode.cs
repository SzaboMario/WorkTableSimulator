using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTableSimulator
{
    public enum OperationMode
    {
        Stopped,
        Idle,
        Running,
        OnError,
        OnEStop,
    }
}
