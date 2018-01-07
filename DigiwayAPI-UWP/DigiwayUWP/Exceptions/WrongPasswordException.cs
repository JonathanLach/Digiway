using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class WrongPasswordException : PasswordChangeException
    {
        private string _message = "Your current password is wrong.";
        public override string Message
        {
            get { return _message; }
        }
    }
}
