using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class LoginException : Exception
    {
        private string _message = "Sign in failed";
        public override string Message
        {
            get { return _message; }
        }

        private string _title = "Login Error";
        public string Title
        {
            get { return _title; }
        }
    }
}
