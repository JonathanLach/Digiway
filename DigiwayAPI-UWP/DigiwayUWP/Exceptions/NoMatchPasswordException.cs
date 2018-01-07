using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class NoMatchPasswordException : PasswordChangeException
    {
        private string _message = "New password and the confirmation don't match.";
        public override string Message
        {
            get { return _message; }
        }
    }
}
