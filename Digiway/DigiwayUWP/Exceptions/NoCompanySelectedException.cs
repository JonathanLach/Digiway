using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class NoCompanySelectedException : EventFormException
    {
        private string _message = "No company selected";
        public override string Message
        {
            get { return _message; }
        }
    }
}
