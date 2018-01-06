using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class NotCreatedEventException : EventException
    {
        private string _message = "The event must be created before editing points of interest.";
        public override string Message
        {
            get { return _message; }
        }
    }
}
