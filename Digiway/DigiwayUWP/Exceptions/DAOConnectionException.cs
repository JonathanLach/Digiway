using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class DAOConnectionException : Exception
    {
        private string _message = "Connection to the service impossible";
        public override string Message
        {
            get { return _message; }
        }
    }
}
