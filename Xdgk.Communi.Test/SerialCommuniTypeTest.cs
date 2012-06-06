using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi;
using NUnit.Framework ;

namespace Xdgk.Communi.Test
{
    [TestFixture]
    public class SerialCommuniTypeTest
    {
        [Test]
        public void t1()
        {
            SerialCommuniType sct = new SerialCommuniType("com1",
                9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);

            string s = sct.ToXml();

            Console.WriteLine(s);
            CommuniType ct = CommuniTypeFactory.Create(s);
            Assert.IsNotNull(ct);

            Assert.IsTrue(ct is SerialCommuniType);
            SerialCommuniType sct2 = ct as SerialCommuniType;

            Assert.IsTrue(sct2.PortName == sct.PortName );
            Assert.AreEqual(sct2.BaudRate , sct.BaudRate );
            Assert.AreEqual(sct2.DataBits , sct.DataBits );
            Assert.AreEqual(sct2.Parity , sct.Parity );
            Assert.AreEqual(sct2.StopBits , sct.StopBits);
        }
    }


    [TestFixture]
    public class SerialCommuniPortTest
    {
        [Test]
        public void t1()
        {
            SerialCommuniType sct = new SerialCommuniType("com1",
                9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            SerialCommuniPort cp = CommuniPortFactory.CreateSerialCommuniPort(sct);
            cp.Write( System.Text.Encoding.ASCII.GetBytes ("test string."));

            Assert.IsTrue(cp.IsReady);
            cp.SerialPort.Close();
            
        }
    }
}
