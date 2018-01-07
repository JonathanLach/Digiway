using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class NoEventSelectedException : EventException
    {
        private string _message = "No event selected";
        public override string Message
        {
            get { return _message; }
        }
    }
}
