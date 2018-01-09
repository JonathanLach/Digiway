using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class DAOConcurrencyException : DAOException
    {
        private string _message = "Another user modified the event at the same time. Try again.";
        public override string Message
        {
            get { return _message; }
        }
    }
}
