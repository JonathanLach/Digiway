using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class PasswordChangeException : Exception
    {
        private string _message = "Password change error";
        public override string Message
        {
            get { return _message; }
        }

        private string _title = "Password change error";
        public string Title
        {
            get { return _title; }
        }
    }
}
