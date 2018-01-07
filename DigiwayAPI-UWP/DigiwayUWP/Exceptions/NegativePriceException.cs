using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class NegativePriceException : EventException
    {
        private string _message = "Price must be >= 0";
        public override string Message
        {
            get { return _message; }
        }
    }
}
