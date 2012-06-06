using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Xdgk.Communi.Test
{
    [TestFixture]
    public class CommuniPortManagerTest
    {
        [Test]
        public void t1()
        {
            CommuniSoft cs = new CommuniSoft();
            CommuniType ct = new SocketCommuniType("1234");
            CommuniPort cp = cs.CommuniPortManager.FindCommuniPort(ct);
            Assert.IsNull(cp);
        }
    }
}
