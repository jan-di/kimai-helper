using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimaiHelper.Kimai
{
    internal class RequestException : Exception
    {
        public RequestException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
