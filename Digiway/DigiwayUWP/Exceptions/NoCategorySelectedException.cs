using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class NoCategorySelectedException : EventFormException
    {
        private string _message = "No category selected";
        public override string Message
        {
            get { return _message; }
        }
    }
}
