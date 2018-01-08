using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class DAOException : Exception
    {
        private string _title = "Service Error";
        public string Title
        {
            get { return _title; }
        }

        private string _message = "Error with the service";
        public override string Message
        {
            get { return _message; }
        }
    }
}
