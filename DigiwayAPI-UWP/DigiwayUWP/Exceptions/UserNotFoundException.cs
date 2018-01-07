using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class UserNotFoundException : LoginException
    {
        private string _message = "Incorrect Username";
        public override string Message
        {
            get { return _message; }
        }
    }
}
