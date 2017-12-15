using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class PushpinTitleTakenException : EventException
    {
        private string _message = "Pushpin title already taken, it must be unique.";
        public override string Message
        {
            get { return _message; }
        }
    }
}
