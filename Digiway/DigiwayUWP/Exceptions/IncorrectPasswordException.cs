using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class IncorrectPasswordException : LoginException
    {
        private string _message = "Incorrect Password";
        public override string Message
        {
            get { return _message; }
        }
    }
}
