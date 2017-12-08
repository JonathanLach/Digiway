using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class AnteriorEventDateException : EventFormException
    {
        private string _message = "The event date can't be in the past.";
        public override string Message
        {
            get { return _message; }
        }
    }
}
