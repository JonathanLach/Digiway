using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiwayUWP.Exceptions
{
    public class NotEnoughMoneyException : Exception
    {
        private string _message = "You've not enough money to withdraw";
        public override string Message
        {
            get { return _message; }
        }

        private string _title = "Transfer error";
        public string Title
        {
            get { return _title; }
        }
    }
}
