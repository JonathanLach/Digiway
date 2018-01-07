using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class EventException : Exception
    {
        private string _message = "Incorrect form";
        public override string Message
        {
            get { return _message; }
        }

        private string _title = "Form error";
        public string Title
        {
            get { return _title; }
        }
    }
}
