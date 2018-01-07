using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class EmptyFieldException : EventException
    {
        private string _fieldName;

        private string _message;
        public override string Message
        {
            get { return _message; }
        }

        public EmptyFieldException(string fieldName)
        {
            _fieldName = fieldName;
            _message = "The field " + _fieldName + " hasn't been filled";
        }
    }
}
