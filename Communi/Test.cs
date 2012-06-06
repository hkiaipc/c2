using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi;

namespace Communi
{
    public class Test
    {
        public CommuniSoft _soft;

        public Test()
        {
            _soft = CommuniSoftFactory.GetCommuniSoft();
        }
    }
}
