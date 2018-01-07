using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class NoPushpinFoundException : EventException
    {
        private string _message = "No pushpin found with this title";
        public override string Message
        {
            get { return _message; }
        }
    }
}
