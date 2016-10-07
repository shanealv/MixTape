using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixTapeApp.Services
{
    class DummyService : IDummyService
    {
        public string GetMessage ()
        {
            return "This is a new Message";
        }
    }
}
