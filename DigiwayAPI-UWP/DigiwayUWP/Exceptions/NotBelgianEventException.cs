using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class NotBelgianEventException : EventException
    {
        private string _message = "The ZIP must be Belgian (4 digits). Abroad events are not allowed yet.";
        public override string Message
        {
            get { return _message; }
        }
    }
}
