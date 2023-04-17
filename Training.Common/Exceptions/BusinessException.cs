using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string Message) : base(Message)
        {
        }
        public BusinessException(string message, Exception exception) : base(message, exception)
        {

        }

    }
}
