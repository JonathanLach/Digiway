using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class AccessNotGrantedException : LoginException
    {
        private string _message = "You must be an event organisator to access this app";
        public override string Message
        {
            get { return _message; }
        }
    }
}
