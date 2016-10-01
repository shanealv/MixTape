using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTapeApp.Command
{
    /// <summary>
    /// Mutual Exclusion Utility to synchronize across Tasks and 
    /// manage early termination of Tasks without the need of a 
    /// cancellation token.
    /// </summary>
    class AsyncMutex
    {
        public bool Locked { get; set; } = false;
    }
}
