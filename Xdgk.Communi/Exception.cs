using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    public class AssemblyException : Exception 
    {
        public AssemblyException(string msg)
            : base(msg)
        {

        }

        public AssemblyException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
